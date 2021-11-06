import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Currency } from "../models/currency"
 

@Injectable({
  providedIn: "root"
})
export class CurrencyService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getCurrencies(): Promise<Currency[]> {
    return this._http.get<Currency[]>('api/currencies').toPromise();
  }
}
