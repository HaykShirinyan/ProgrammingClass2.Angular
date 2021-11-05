import { Component } from "@angular/core";
import { Currency } from "../../shared/models/currency";


@Component({
  templateUrl: './create-currency.component.html'
})

export class CreateCurrencyComponent {
  public currency: Currency = {};
}
