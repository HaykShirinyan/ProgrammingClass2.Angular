import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ProductBrand } from "../models/product-brand";

@Injectable({
  providedIn: 'root'
})
export class ProductBrandService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public async getAll(productId: number): Promise<ProductBrand[]> {
    return await this._http
      .get<ProductBrand[]>('api/products/' + productId + '/brands')
      .toPromise();
  }

  public async add(productBrand: ProductBrand): Promise<ProductBrand> {
    return await this._http
      .post<ProductBrand>('api/products/' + productBrand.productId + '/brands', productBrand)
      .toPromise();
  }

  public async delete(productBrand: ProductBrand): Promise<ProductBrand> {
    return await this._http
      .delete<ProductBrand>('api/products/' + productBrand.productId + '/brands/' + productBrand.brandId)
      .toPromise();
  }
}
