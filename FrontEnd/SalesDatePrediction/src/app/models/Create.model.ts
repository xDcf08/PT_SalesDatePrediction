export type CreateOrder = {
  empId: number;
  custId: number;
  shipperId: number;
  shipName: string;
  shipAddress: string;
  shipCity: string;
  shipCountry: string;
  orderDate: Date;
  requiredDate: Date;
  shippedDate: Date;
  freight: number;
  productId: number;
  unitPrice: number;
  qty: number;
  discount: number;
}