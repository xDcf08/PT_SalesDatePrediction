import {AfterViewInit, Component, inject, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { SalesDatePrediction } from '../../models/SalesDataPrediction.model';
import { GetClientService } from '../../services/data.service';
import { DatePipe } from '@angular/common';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialog } from '@angular/material/dialog';
import { TableModalComponent } from '../Modal/Modal-table/modal-table.component';
import { OrderDialogComponent } from '../Modal/Modal-form/modal-form.component';

/**
 * @title Table with pagination
 */
@Component({
  selector: 'app-table',
  styleUrl: 'table.component.css',
  templateUrl: 'table.component.html',
  imports: [MatTableModule, MatPaginatorModule, MatFormFieldModule, MatLabel, MatInputModule, DatePipe],
})
export class TablePagination implements AfterViewInit {
  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextOrderDatePrediction', 'viewOrder', 'newOrder'];
  dataSource = new MatTableDataSource<SalesDatePrediction>([]);

  /**
   *
   */

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private getClientService: GetClientService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.obtenerDatos()
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  obtenerDatos() : void{
    this.getClientService.obtenerData().subscribe({
      next: (data) => {
        this.dataSource.data = data;
      },
      error: (error) => {
        console.error('Error obteniendo datos:', error);
      }
    });
  }
  viewOrderDetail({custId, customerName} : {custId: number, customerName: string}){
    this.dialog.open(TableModalComponent, {
      width: '800px',
      height: 'auto',
      minWidth: '800px',
      minHeight: '800px',
      data: {
        custId,
        customerName,
      },
    });
  }

  newOrder(){
    this.dialog.open(OrderDialogComponent, {
      width: '600px',
      height: 'auto',
      minWidth: '600px',
      minHeight: '600px',
    });
  }
}
