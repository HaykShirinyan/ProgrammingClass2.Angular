import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/services/product-type.service";

@Component({
  templateUrl: '/create-product-type.component.html'
})

export class CreateProductTypeComponent {
  private readonly _productTypeService: ProductTypeService;
  private readonly _router: Router;

  public productType: ProductType = {};

  constructor(productTypeService: ProductTypeService, router: Router) {
    this._productTypeService = productTypeService;
    this._router = router;
  }

  public async createProductType(): Promise<void> {
    await this._productTypeService.createProductType(this.productType);
    this._router.navigate(['product-types']);
  }
}
