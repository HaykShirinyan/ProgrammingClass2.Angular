import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ProductCategory } from "../models/product-category";

@Injectable({
  providedIn: 'root'
})
export class ProductCategoryService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public async getAll(productId: number): Promise<ProductCategory[]> {
    return await this._http
      .get<ProductCategory[]>('api/products/' + productId + '/categories')
      .toPromise();
  }

  public async add(productCategory: ProductCategory): Promise<ProductCategory> {
    return await this._http
      .post<ProductCategory>('api/products/' + productCategory.productId + '/categories', productCategory)
      .toPromise();
  }

  public async delete(productCategory: ProductCategory): Promise<ProductCategory> {
    return await this._http
      .delete<ProductCategory>('api/products/' + productCategory.productId + '/categories/' + productCategory.categoryId)
      .toPromise();
  }
}
