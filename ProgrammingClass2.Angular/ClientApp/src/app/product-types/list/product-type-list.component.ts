import { HttpClient } from "@angular/common/http";
import { Type } from "@angular/compiler";
import { Component, OnInit } from "@angular/core";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/services/product-type.service";

@Component({
  templateUrl: './product-type-list.component.html'
})
export class ProductTypeListComponent implements OnInit {
  private readonly _productTypeService: ProductTypeService;

  public productTypes: ProductType[];
  public isLoading: boolean;

  constructor(productTypeService: ProductTypeService) {
    this._productTypeService = productTypeService;
  }

  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;

      this.productTypes = await this._productTypeService.getProductTypes();
    } finally {
      this.isLoading = false;
    }
  }

  public spinnerHidden(): void {
    this.isLoading = false;
  }
   
  
}
