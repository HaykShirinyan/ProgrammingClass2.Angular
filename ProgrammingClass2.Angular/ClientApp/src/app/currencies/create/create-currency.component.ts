import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Currency } from "../../shared/models/currency";
import { CurrencyService } from "../../shared/services/currency.service";
import { NgForm } from "@angular/forms";



@Component({
  templateUrl: './create-currency.component.html'
})

export class CreateCurrencyComponent {
  private readonly _router: Router;
  private readonly _currencyService: CurrencyService;

  public currency: Currency = {};

  constructor(currencyService: CurrencyService, router: Router) {
    this._currencyService = currencyService;
    this._router = router;
  }


  public async createCurrency(form: NgForm): Promise<void> {
    if (form.invalid) {
      await this._currencyService.createCurrency(this.currency);
      this._router.navigate(['currencies']);
    }
  }
}
