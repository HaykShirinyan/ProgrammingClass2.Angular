import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Currency } from "../../shared/models/currency";
import { CurrencyService } from "../../shared/services/currency.service";

@Component({
  templateUrl: './edit-currency.component.html'
})
export class EditCurrencyComponent implements OnInit {
  private readonly _currencyService: CurrencyService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;

  public currency: Currency;

  constructor(
    currencyService: CurrencyService,
    activeRoute: ActivatedRoute,
    router: Router
  ) {
    this._currencyService = currencyService;
    this._activeRoute = activeRoute;
    this._router = router;
  }

  public async ngOnInit(): Promise<void> {
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    await this._currencyService.getAll();
  }

  public async updateCurrency(form: NgForm): Promise<void> {
    await this._currencyService.getAll();
    this._router.navigate(['currencies']);
  }
}
