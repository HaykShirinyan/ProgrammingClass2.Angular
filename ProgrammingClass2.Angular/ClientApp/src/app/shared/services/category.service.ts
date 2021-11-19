import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Category } from "../models/category";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public async getAll(): Promise<Category[]> {
    return await this._http
      .get<Category[]>('api/categories')
      .toPromise();
  }
}
