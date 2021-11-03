import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Product } from "../../shared/models/product";
import { ProductService } from "../../shared/services/product.service";

@Component({
  templateUrl: './edit-product.component.html'
})
export class EditProductComponent implements OnInit {
  private readonly _productService: ProductService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;

  public product: Product;

  constructor(
    productService: ProductService,
    activeRoute: ActivatedRoute,
    router: Router
  ) {
    this._productService = productService;
    this._activeRoute = activeRoute;
    this._router = router;
  }

  public async ngOnInit(): Promise<void> {
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    this.product = await this._productService.getProduct(id);
  }

  public async updateProduct(form: NgForm): Promise<void> {
    await this._productService.updateProduct(this.product);
    this._router.navigate(['products']);
  }
}
