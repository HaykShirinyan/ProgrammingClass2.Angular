import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Brand } from "../models/brand";

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getBrands(): Promise<Brand[]> {
    return this._http
      .get<Brand[]>('api/brands')
      .toPromise();
  }

  public getBrand(id: number): Promise<Brand> {
    return this._http
      .get<Brand>('api/brands/' + id)
      .toPromise();
  }

  public createBrand(brand: Brand): Promise<Brand> {
    return this._http
      .post<Brand>('api/brands', brand)
      .toPromise();
  }

  public updateBrand(brand: Brand): Promise<Brand> {
    return this._http
      .put<Brand>('api/brands/' + brand.id, brand)
      .toPromise();
  }
}
