import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { ProductType } from "../../shared/models/productType";
import { ProductTypeService } from "../../shared/services/productType.service";

@Component({
  templateUrl: './create-productType.component.html'
})
export class CreateProductType {
  private readonly _router: Router;
  private readonly _productTypeService: ProductTypeService;

  constructor(productTypeService: ProductTypeService, router: Router) {
    this._productTypeService = productTypeService;
    this._router = router;
  }

  public productType: ProductType = {};

  public async createProductType(): Promise<void> {
    await this._productTypeService.createProductType(this.productType);
    this._router.navigate(["product-types"]);
}
}
