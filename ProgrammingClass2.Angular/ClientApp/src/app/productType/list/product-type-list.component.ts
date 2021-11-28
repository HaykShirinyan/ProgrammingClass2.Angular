import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ProductType } from "../../shared/models/productType";
import { ProductTypeService } from "../../shared/services/productType.service";

@Component({
  templateUrl:'./product-type-list.component.html'
})
export class ProductTypeListComponent implements OnInit {
  private readonly _productTypeServise: ProductTypeService;

  public productTypes: ProductType[];
  public isLoading: boolean;

  constructor(productTypeService: ProductTypeService) {
    this._productTypeServise = productTypeService;
  }

  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;

      this.productTypes = await this._productTypeServise.getProductType();
    } finally {
      this.isLoading = false;
     }
  }

  public spinnerHidden(): void {
    this.isLoading = false;
  }
}

