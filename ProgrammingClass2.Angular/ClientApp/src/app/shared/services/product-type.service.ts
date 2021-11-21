import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ProductType } from "../models/product-type";

@Injectable({
  providedIn: 'root'
})
export class ProductTypeService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getAll(): Promise<ProductType[]> {
    return this._http
      .get<ProductType[]>('api/product-types')
      .toPromise();
  }

  public create(productType: ProductType): Promise<ProductType> {
    return this._http
      .post<ProductType>('api/product-types', productType)
      .toPromise();
  }
}
