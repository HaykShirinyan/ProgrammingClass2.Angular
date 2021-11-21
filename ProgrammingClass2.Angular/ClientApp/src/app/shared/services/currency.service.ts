import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Currency } from "../models/currency";

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public async getAll(): Promise<Currency[]> {
    return await this._http
      .get<Currency[]>('api/currencies')
      .toPromise();
  }
}

