import { HttpClient } from "@angular/common/http";
import { Type } from "@angular/compiler";
import { Component, OnInit } from "@angular/core";
import { Currency } from "../../shared/models/currency";
import { CurrencyService } from "../../shared/services/currency.service";


@Component({
  templateUrl: './currency-list.component.html'
})

export class CurrencyListComponent implements OnInit {
  private readonly _currencyService: CurrencyService;

  public currencies: Currency[];
  public isLoading: boolean;

  constructor(currencyService: CurrencyService) {
    this._currencyService = currencyService;
  }

  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;

      this.currencies = await this._currencyService.getCurrencies();
    } finally {
      this.isLoading = false;
    }
  }

  public spinnerHidden(): void {
    this.isLoading = false;
  }
}
