import { HttpClient } from "@angular/common/http";
import { Type } from "@angular/compiler";
import { Component, OnInit } from "@angular/core";
import { Currency } from "../../shared/models/currency";


@Component({
  templateUrl: './currency-list.component.html'
})

export class CurrencyListComponent implements OnInit {
  private readonly _http: HttpClient;

  public currencies: Currency[];

  constructor(http: HttpClient) {
    this._http = http;
  }

  public ngOnInit(): void {

    this._http.get<Currency[]>('api/currencies').subscribe(apiCurrencies => {
      this.currencies = apiCurrencies
    });
  }
}
