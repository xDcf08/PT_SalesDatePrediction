import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { GetClientService } from '../../../services/data.service';
import { Employees, Products, Shippers } from '../../../models/form.model';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { provideNativeDateAdapter} from '@angular/material/core';
import { forkJoin } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-order-dialog',
  templateUrl: './modal-form.component.html',
  styleUrls: ['./modal-form.component.scss'],
  providers: [provideNativeDateAdapter()],
  imports: [CommonModule,MatDialogModule,MatDividerModule,MatFormFieldModule,MatSelectModule,MatNativeDateModule, MatInputModule, MatDatepickerModule]
})
export class OrderDialogComponent {
  orderForm: FormGroup;
  employees : Employees[] = [];
  shippers : Shippers[] = [];
  products : Products[] = [];

  constructor(
    private fb: FormBuilder,
    private getClientService: GetClientService,
    public dialogRef: MatDialogRef<OrderDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.orderForm = this.fb.group({
      employee: ['', Validators.required],
      shipper: ['', Validators.required],
      shipName: ['', Validators.required],
      shipAddress: ['', Validators.required],
      shipCity: ['', Validators.required],
      shipCountry: ['', Validators.required],
      orderDate: ['', Validators.required],
      requiredDate: ['', Validators.required],
      shippedDate: ['', Validators.required],
      freight: ['', [Validators.required, Validators.min(0)]],
      product: ['', Validators.required],
      unitPrice: ['', [Validators.required, Validators.min(0)]],
      quantity: ['', [Validators.required, Validators.min(1)]],
      discount: ['', [Validators.required, Validators.min(0), Validators.max(100)]]
    });
  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.ObtenerDatos();
  }

  ObtenerDatos(): void {
    forkJoin({
      employees: this.getClientService.getAllEmployees(),
      shippers: this.getClientService.getAllShippers(),
      products: this.getClientService.getAllProducts()
    }).subscribe({
      next: (result) => {
        this.employees = result.employees;
        this.shippers = result.shippers;
        this.products = result.products;
      }
    });
  }

  close() {
    this.dialogRef.close();
  }

  save() {
    if (this.orderForm.valid) {
      console.log('Order Data:', this.orderForm.value);
      this.dialogRef.close(this.orderForm.value);
    }
  }
}
