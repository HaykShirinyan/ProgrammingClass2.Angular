import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/services/product-type.service";

@Component({
  templateUrl: './create-product-type.component.html'
})
export class CreateProductTypeComponent {
  private readonly _productTypeService: ProductTypeService;
  private readonly _router: Router;

  public productType: ProductType = {};
  public isLoading: boolean;

  constructor(productTypeService: ProductTypeService, router: Router) {
    this._productTypeService = productTypeService;
    this._router = router;
  }

  public async createProductType(form: NgForm): Promise<void> {
    if (form.valid) {
      try {
        this.isLoading = true;

        await this._productTypeService.getAll();
        this._router.navigate(['product-types']);
      } finally {
        this.isLoading = false;
      }
    }
  }
}
