import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Order } from '../../../models/Order.model';
import { GetClientService } from '../../../services/data.service';

@Component({
  selector: 'app-table-modal',
  templateUrl: 'modal-table.component.html',
  styleUrls: ['modal-table.component.css'],
  imports: [DatePipe, MatTableModule, MatPaginatorModule]
})
export class TableModalComponent implements AfterViewInit {
  displayedColumns: string[] = ['orderId', 'requiredDate', 'shippedDate', 'shipName', 'shipAddress', 'shipCity'];
  dataSource = new MatTableDataSource<Order>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  constructor(
    public dialogRef: MatDialogRef<TableModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private getClientService: GetClientService
  ) 
  {
  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.ObtenerDatos();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ObtenerDatos() : void{
    this.getClientService.GetOrderByCustomerId(this.data.custId).subscribe({
      next: (data) => {
        this.dataSource.data = data;
      },
      error: (error) => {
        console.error('Error obteniendo datos:', error);
      }
    })
  }

  closeModal() {
    this.dialogRef.close();
  }
}
