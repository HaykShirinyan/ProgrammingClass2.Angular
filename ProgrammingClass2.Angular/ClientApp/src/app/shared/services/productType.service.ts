import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ProductType } from "../models/productType";

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
      .get<ProductType[]>('api/productTypes')
      .toPromise();
  }

  public getProductType(id: number): Promise<ProductType> {
    return this._http
      .get<ProductType>('api/productTypes/' + id)
      .toPromise();
  }

  public createProductType(productType: ProductType): Promise<ProductType> {
    return this._http
      .post<ProductType>('api/productTypes', productType)
      .toPromise();
  }

  public updateProductType(productType: ProductType): Promise<ProductType> {
    return this._http
      .put<ProductType>('api/productTypes/' + productType.id, productType)
      .toPromise();
  }
}
