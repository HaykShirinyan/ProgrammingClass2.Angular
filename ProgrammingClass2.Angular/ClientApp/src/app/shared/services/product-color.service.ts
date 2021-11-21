import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ProductColor } from "../models/product-color";

@Injectable({
  providedIn: 'root'
})
export class ProductColorService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public async getAll(productId: number): Promise<ProductColor[]> {
    return await this._http
      .get<ProductColor[]>('api/products/' + productId + '/colors')
      .toPromise();
  }

  public async add(productColor: ProductColor): Promise<ProductColor> {
    return await this._http
      .post<ProductColor>('api/products/' + productColor.productId + '/colors', productColor)
      .toPromise();
  }

  public async delete(productColor: ProductColor): Promise<ProductColor> {
    return await this._http
      .delete<ProductColor>('api/products/' + productColor.productId + '/colors/' + productColor.colorId)
      .toPromise();
  }
}
