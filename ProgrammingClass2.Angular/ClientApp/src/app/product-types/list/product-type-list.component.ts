import { HttpClient } from "@angular/common/http";
import { Type } from "@angular/compiler";
import { Component, OnInit } from "@angular/core";
import { ProductType } from "../../shared/models/product-type";

@Component({
  templateUrl: './product-type-list.component.html'
})

export class ProductTypeListComponent implements OnInit {
  private readonly _http: HttpClient;

  public products: ProductType[];
    productType: ProductType[];

  constructor(http: HttpClient) {
    this._http = http;
  }

  public ngOnInit(): void {
  
    this._http.get<ProductType[]>('api/product-types').subscribe(apiProductTypes => {
      this.productType = apiProductTypes
    });
  }
}
