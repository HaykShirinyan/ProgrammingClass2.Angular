import { Component, OnInit } from "@angular/core";
import { Currency } from "../../shared/models/currency";
import { CurrencyService } from "../../shared/services/currency.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";


@Component({
  templateUrl: './edit-currency.component.html'
})

export class EditCurrencyComponent implements OnInit {
  private readonly _currencyService: CurrencyService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;

  public currency: Currency;

  constructor(currencyService: CurrencyService, activeRoute: ActivatedRoute, router:Router) {
    this._currencyService = currencyService;
    this._router = router;
    this._activeRoute = activeRoute;
  }

  public async ngOnInit(): Promise<void> {
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    this.currency = await this._currencyService.getCurrency(id);
  }

  public async updateCurrency(form: NgForm): Promise<void> {
    await this._currencyService.updateCurrency(this.currency);
    this._router.navigate(['currencies']);
  }
 }
