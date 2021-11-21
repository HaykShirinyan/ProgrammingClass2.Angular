import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Currency } from "../../shared/models/currency";
import { CurrencyService } from "../../shared/services/currency.service";

@Component({
  templateUrl: './create-currency.component.html'
})
export class CreateCurrenyComponent {
  private readonly _currencyService: CurrencyService;
  private readonly _router: Router;

  public currency: Currency = {};

  constructor(currencyService: CurrencyService, router: Router) {
    this._currencyService = currencyService;
    this._router = router;
  }

  public async createCurrency(form: NgForm): Promise<void> {
    if (form.valid) {
      await this._currencyService.getAll();
      this._router.navigate(['currencies']);
    }
  }
}
