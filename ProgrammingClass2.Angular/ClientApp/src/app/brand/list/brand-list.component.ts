import { HttpClient } from "@angular/common/http";
import { Type } from "@angular/compiler";
import { Component, OnInit } from "@angular/core";
import { Brand } from "../../shared/models/brand";
import { BrandService } from "../../shared/services/brand.service";



@Component({
  templateUrl: './brand-list.component.html'
})

export class BrandListComponent implements OnInit {
  private _brandService: BrandService;

  public brands: Brand[];
  public isLoading: boolean;

  constructor(brandService: BrandService) {
    this._brandService = brandService;
  }

  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;

      this.brands = await this._brandService.getBrands();
    } finally {
      this.isLoading = false;
    }
  }

  public spinnerHidden(): void {
    this.isLoading = false;
  }
}
