import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ProductCurrency } from "../models/product-currency";

@Injectable({
  providedIn: 'root'
})

export class ProductCurrencyService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public async getAll(productId: number): Promise<ProductCurrency[]> {
    return await this._http
      .get<ProductCurrency[]>('api/products' + productId + '/currencies')
      .toPromise();
  }

  public async add(productCurrency: ProductCurrency): Promise<ProductCurrency> {
    return await this._http
      .post<ProductCurrency>('api/products/' + productCurrency.productId + '/currencies/', productCurrency)
      .toPromise();
  }

  public async delete(productCurrency: ProductCurrency): Promise<ProductCurrency> {
    return await this._http
      .delete<ProductCurrency>('api/products/' + productCurrency.productId + '/currencies/' + productCurrency.currencyId)
      .toPromise();
  }
}
