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

  public getProductTypes(): Promise<ProductType[]> {
    return this._http
      .get<ProductType[]>('api/product-types')
      .toPromise();
  }

  public getProductType(id: number): Promise<ProductType> {
    return this._http
      .get<ProductType>('api/product-types/' + id)
      .toPromise();
  }

  public createProductType(productType: ProductType): Promise<ProductType> {
    return this._http
      .post<ProductType>('api/product-types', productType)
      .toPromise();
  }

  public updateProductType(productType: ProductType): Promise<ProductType> {
    return this._http
      .put<ProductType>('api/product-types/' + productType.id, productType)
      .toPromise();
  }
}
