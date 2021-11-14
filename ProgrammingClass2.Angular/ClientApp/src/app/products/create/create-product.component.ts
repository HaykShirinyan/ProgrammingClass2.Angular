import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Product } from "../../shared/models/product";
import { ProductType } from "../../shared/models/productType";
import { ProductService } from "../../shared/services/product.service";
import { ProductTypeService } from "../../shared/services/productType.service";

@Component({
  templateUrl: './create-product.component.html'
})
export class CreateProductComponent implements OnInit {
  private readonly _productService: ProductService;
  private readonly _router: Router;
  private readonly _productTypeService: ProductTypeService;


  // {} nshanakum e datark object.
  public product: Product = {};
  public productTypes: ProductType[] = [];

  constructor(productService: ProductService, router: Router, productTypeService: ProductTypeService) {
    this._productService = productService;
    this._router = router;
    this._productTypeService = productTypeService;
  }

  public async ngOnInit(): Promise<void> {
    this.productTypes = await this._productTypeService.getProductType();
  }
  public async createProduct(form: NgForm): Promise<void> {
    if (form.valid) {
      await this._productService.createProduct(this.product);
      this._router.navigate(['products']);
    }
  }
}
