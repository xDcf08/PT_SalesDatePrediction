import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule, MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { GetClientService } from '../../../services/data.service';
import { Employees, Products, Shippers } from '../../../models/form.model';
import { DateAdapter, MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { provideNativeDateAdapter} from '@angular/material/core';
import { forkJoin } from 'rxjs';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { CreateOrder } from '../../../models/Create.model';
import { CustomDateAdapter } from '../../../utils/date.adapter';

@Component({
  selector: 'app-order-dialog',
  templateUrl: './modal-form.component.html',
  styleUrls: ['./modal-form.component.css'],
  providers: [provideNativeDateAdapter(),
    {
      provide: DateAdapter,
      useClass: CustomDateAdapter
    }
  ],
  imports: [CommonModule,
    MatDialogModule,
    MatDividerModule,
    MatFormFieldModule,
    MatSelectModule,
    MatNativeDateModule, 
    MatInputModule, 
    MatDatepickerModule, 
    MatButtonModule,
    ReactiveFormsModule]
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
    @Inject(MAT_DIALOG_DATA) public data: any,
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

  async save() {
    if (this.orderForm.valid) {
      const orderData: CreateOrder = {
        empId: this.orderForm.value.employee, 
        custId: this.data.custId,// 👈 Mapea los nombres correctamente
        shipperId: this.orderForm.value.shipper,
        shipName: this.orderForm.value.shipName,
        shipAddress: this.orderForm.value.shipAddress,
        shipCity: this.orderForm.value.shipCity,
        shipCountry: this.orderForm.value.shipCountry,
        orderDate: this.orderForm.value.orderDate, // Formatear fechas
        requiredDate: this.orderForm.value.requiredDate,
        shippedDate: this.orderForm.value.shippedDate,
        freight: this.orderForm.value.freight,
        productId: this.orderForm.value.product,
        unitPrice: this.orderForm.value.unitPrice,
        qty: this.orderForm.value.quantity,
        discount: this.orderForm.value.discount
      };

      console.log(orderData)
      // Simulate API call to save data
      let resp = await this.getClientService.createOrder(orderData);

      if (resp.statusCode === 201) {
        this.dialogRef.close(true);
      } else {
        console.error('Error saving order');
      }
    }
  }
}
