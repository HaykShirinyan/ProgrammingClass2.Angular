import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ProductType } from "../../shared/models/productType";
import { ProductTypeService } from "../../shared/services/productType.service";

@Component({
  templateUrl:'./productType-list.component.html'
})
export class ProductTypeListComponent implements OnInit {
  private readonly _productTypeServise: ProductTypeService;

  public productTypes: ProductType[];

  constructor(productTypeService: ProductTypeService) {
    this._productTypeServise = productTypeService;
  }

  public async ngOnInit(): Promise<void> {
    this.productTypes = await this._productTypeServise.getProductType();
    }
  }

