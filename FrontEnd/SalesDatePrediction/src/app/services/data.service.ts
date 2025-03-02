import { Injectable } from '@angular/core';
import { SalesDatePrediction } from '../models/SalesDataPrediction.model';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Order } from '../models/Order.model';
import { response } from 'express';
import { Employees, Products, Shippers } from '../models/form.model';

@Injectable({
  providedIn: 'root'
})
export class GetClientService {

  private apiUrl = environment.apiUrl

  constructor(private http: HttpClient) { }
  public obtenerData() : Observable<SalesDatePrediction[]>{

    return this.http.get<ResponseUrlClientService>(`${this.apiUrl}customers/get-client-with-lastOrderDate-and-nextPredictedOrder`).pipe(map(
      response => response.data,
    ));
  }

  public GetOrderByCustomerId(custId: number): Observable<Order[]>
  {
    return this.http.get<ResponseUrlOrderService>(`${this.apiUrl}orders/get-orders-by-customer/${custId}`).pipe(map(
      response => response.data,
    ))
  }

  public getAllEmployees(): Observable<Employees[]> {
    return this.http.get<ResponseUrlEmployeesService>(`${this.apiUrl}employees/get-all`).pipe(map(
      response => response.data,
    ))
  }

  public getAllShippers() : Observable<Shippers[]> {
    return this.http.get<ResponseUrlShippersService>(`${this.apiUrl}shippers/get-all`).pipe(map(
      response => response.data,
    ))
  }

  public getAllProducts() : Observable<Products[]> {
    return this.http.get<ResponseUrlProductsService>(`${this.apiUrl}products/get-all`).pipe(map(
      response => response.data,
    ))
  }

}

type ApiResponse<T> = {
  statusCode: number;
  message: string;
  success: boolean;
  data: T[];
};

// Ahora puedes reutilizarlo para diferentes respuestas:
type ResponseUrlClientService = ApiResponse<SalesDatePrediction>;
type ResponseUrlOrderService = ApiResponse<Order>;
type ResponseUrlEmployeesService = ApiResponse<Employees>;
type ResponseUrlShippersService = ApiResponse<Shippers>;
type ResponseUrlProductsService = ApiResponse<Products>;