import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Product } from "../models/product";

// @Injectable nshanakum e, vor karox enq ays service urish component-neri constructor-neri mejic pahanjel
// providedIn: 'root' drvum e nra hamar, vor AppModule-i mej es service dzerqov chavelacnenq
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getProducts(): Promise<Product[]> {
    return this._http
      .get<Product[]>('api/products')
      .toPromise();
  }

  public getProduct(id: number): Promise<Product> {
    return this._http
      .get<Product>('api/products/' + id)
      .toPromise();
  }

  public createProduct(product: Product): Promise<Product> {
    return this._http
      .post<Product>('api/products', product)
      .toPromise();
  }

  public updateProduct(product: Product): Promise<Product> {
    return this._http
      .put<Product>('api/products/' + product.id, product)
      .toPromise();
  }
}
