import { HttpClient } from "@angular/common/http";
import { Type } from "@angular/compiler";
import { Component, OnInit } from "@angular/core";
import { Brand } from "../../shared/models/brand";
import { BrandService } from "../../shared/services/brand.service";



@Component({
  templateUrl: './brand-list.component.html'
})

export class BrandListComponent implements OnInit {
  private readonly _currencyService: BrandService;

  public brands: Brand[];
  private _brandService: BrandService;

  constructor(brandService: BrandService) {
    this._brandService = brandService;
  }

  public async ngOnInit(): Promise<void> {
    this.brands = await this._brandService.getBrands();
  }
}
