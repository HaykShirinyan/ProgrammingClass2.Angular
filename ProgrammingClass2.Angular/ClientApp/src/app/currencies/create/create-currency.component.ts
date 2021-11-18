import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Currency } from "../../shared/models/currency";
import { CurrencyService } from "../../shared/services/currency.service";

@Component({
  templateUrl: '/create-currency.component.html'
})

export class CreateCurrencyComponent {
  private readonly _currencyService: CurrencyService;
  private readonly _router: Router;

  public currency: Currency = {};

  constructor(currencyService: CurrencyService, router: Router) {
    this._currencyService = currencyService;
    this._router = router;
  }  

  public async createCurrency(): Promise<void> {
    await this._currencyService.createCurrency(this.currency);
    this._router.navigate(['currencies']);
  }
}
