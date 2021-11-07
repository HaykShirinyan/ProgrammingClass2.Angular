import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Product } from "../../shared/models/product";
import { ProductService } from "../../shared/services/product.service";

@Component({
  templateUrl: './create-product.component.html'
})
export class CreateProductComponent {
  private readonly _productService: ProductService;
  private readonly _router: Router;

  // {} nshanakum e datark object.
  public product: Product = {};

  constructor(productService: ProductService, router: Router) {
    this._productService = productService;
    this._router = router;
  }

  public async createProduct(form: NgForm): Promise<void> {
    if (form.valid) {
      await this._productService.createProduct(this.product);
      this._router.navigate(['products']);
    }
  }
}
