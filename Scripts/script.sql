---------------------------------------------------------------------------------------------------------------------------------
--Sales Date Prediction
---------------------------------------------------------------------------------------------------------------------------------

WITH Diferencias AS (
	SELECT 
		sc.companyname AS CustomerName,
		so.orderdate,
		LAG(so.orderdate) OVER (PARTITION BY sc.companyname ORDER BY so.orderdate) AS fecha_anterior,
		DATEDIFF(DAY, LAG(so.orderdate) OVER (PARTITION BY sc.companyname ORDER BY so.orderdate), so.orderdate) AS diferencia
	FROM Sales.Orders so
	INNER JOIN Sales.Customers sc ON so.custid = sc.custid
)

select 
CustomerName,
utlima_fecha AS LastOrderDate,
FORMAT(DATEADD(DAY, Promedio_Dias, utlima_fecha), 'yyyy-MM-dd hh:mm:ss', 'es-ES') AS NextPredictedOrder from (
SELECT 
	CustomerName,
	AVG(diferencia) AS Promedio_Dias,
	MAX(orderdate) AS utlima_fecha
FROM Diferencias
GROUP BY CustomerName
) datos

---------------------------------------------------------------------------------------------------------------------------------
--Get Client Orders 
---------------------------------------------------------------------------------------------------------------------------------

select 
	orderid as Orderid,
	requireddate as Requireddate,
	shippeddate as Shippeddate,
	shipname as Shipname,
	shipaddress as Shipaddress,
	shipcity as Shipcity
from Sales.Orders


---------------------------------------------------------------------------------------------------------------------------------
--Get employees 
---------------------------------------------------------------------------------------------------------------------------------

select 
	empid as Empid,
	CONCAT(firstname, ' ' ,lastname) as FullName
from HR.Employees

---------------------------------------------------------------------------------------------------------------------------------
--Get Shippers 
---------------------------------------------------------------------------------------------------------------------------------

select 
	shipperid as Shipperid,
	companyname as Companyname
from Sales.Shippers

---------------------------------------------------------------------------------------------------------------------------------
--Get Products 
---------------------------------------------------------------------------------------------------------------------------------

select
	productid as Productid,
	productname as Productname
from Production.Products

---------------------------------------------------------------------------------------------------------------------------------
--Add New Order 
---------------------------------------------------------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc sp_insert_new_order(
	@json_order nvarchar(max)
)
as
begin

declare @last_id int

begin try
	
	begin tran
	
	create table #temp_data_order (
		Empid int,
		shipperid int,
		Shipname nvarchar(40),
		Shipaddress nvarchar(60),
		Shipcity nvarchar(15),
		Orderdate datetime,
		Requireddate datetime,
		Shippeddate datetime,
		Freight money,
		Shipcountry nvarchar(15),
		Productid int,
		Unitprice money,
		Qty smallint,
		Discount numeric(4,3)
	) 

	insert into #temp_data_order(Empid,shipperid,Shipname,Shipaddress,Shipcity,Orderdate,Requireddate,Shippeddate,Freight,Shipcountry,Productid,Unitprice,Qty,Discount)
	select 
		empid,shipperid,shipname,shipaddress,shipcity,orderdate,requireddate,shippeddate,freight,shipcountry,productid,unitprice,qty,discount
	from openjson(@json_order)
	with(
		empid int,
		shipperid int,
		shipname nvarchar(40),
		shipaddress nvarchar(60),
		shipcity nvarchar(15),
		orderdate datetime,
		requireddate datetime,
		shippeddate datetime,
		freight money,
		shipcountry nvarchar(15),
		productid int,
		unitprice money,
		qty smallint,
		discount numeric(4,3)
	)

	insert into Sales.Orders (empid,shipperid,shipname,shipaddress,shipcity,orderdate,requireddate,shippeddate,freight,shipcountry)
	select 
		Empid,shipperid,Shipname,Shipaddress,Shipcity,Orderdate,Requireddate,Shippeddate,Freight,Shipcountry
	from #temp_data_order

	set @last_id = @@IDENTITY

	insert into Sales.OrderDetails (orderid,productid,unitprice,qty,discount)
	select @last_id, Productid,Unitprice,Qty,Discount
	from #temp_data_order

	if @@TRANCOUNT > 1
	begin
		commit
	end

end try
begin catch
	if @@TRANCOUNT > 1
	begin
		rollback
	end
	print 'hubo un error al insertar los datos';
end catch
end
go