import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { ProductType } from "../../shared/models/productType";
import { ProductTypeService } from "../../shared/services/productType.service";

@Component({
  templateUrl: './create-product-type.component.html'
})
export class CreateProductTypeComponent {
  private readonly _router: Router;
  private readonly _productTypeService: ProductTypeService;

  public productType: ProductType = {};

  constructor(productTypeService: ProductTypeService, router: Router) {
    this._productTypeService = productTypeService;
    this._router = router;
  }

  public async createProductType(form: NgForm): Promise<void> {
    if (form.valid) {
      await this._productTypeService.createProductType(this.productType);
      this._router.navigate(["product-types"]);
    }
  }
}
