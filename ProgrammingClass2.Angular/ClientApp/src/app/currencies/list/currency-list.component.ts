import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Currency } from "../../shared/models/currency";
import { CurrencyService } from "../../shared/services/currency.service";

type NewType = Promise<void>;

@Component({
  templateUrl: './currency-list.component.html'
})
export class CurrencyListComponent implements OnInit {
  private readonly _currencyService: CurrencyService;

  public currencies: Currency[];

  constructor(currencyService: CurrencyService) {
    this._currencyService = currencyService;
  }

  public async ngOnInit(): Promise<void> {
    this.currencies = await this._currencyService.getAll();
  }
}
