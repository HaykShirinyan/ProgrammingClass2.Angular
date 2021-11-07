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

  public getCurrency(id: number): Promise<Currency> {
    return this._http
      .get<Currency>('api/currencies/' + id)
      .toPromise();
  }
  public createCurrency(currency: Currency): Promise<Currency> {
    return this._http
      .post<Currency>('api/currencies', currency)
      .toPromise();
  }

  public updateCurrency(currency: Currency): Promise<Currency> {
    return this._http
      .put<Currency>('api/currencies/' + currency.id, currency)
      .toPromise();
  }
}
