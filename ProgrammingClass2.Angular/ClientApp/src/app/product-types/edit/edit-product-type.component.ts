import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/services/product-type.service";

@Component({
  templateUrl: './edit-product-type.component.html'
})
export class EditProductTypeComponent implements OnInit {
  private readonly _productTypeService: ProductTypeService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;

  public productType: ProductType;
  public isLoading: boolean;

  constructor(
    productTypeService: ProductTypeService,
    activeRoute: ActivatedRoute,
    router: Router
  ) {
    this._productTypeService = productTypeService;
    this._activeRoute = activeRoute;
    this._router = router;
  }

  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;
      let idParameter = this._activeRoute.snapshot.paramMap.get('id');
      let id = parseInt(idParameter);
      this.productType = await this._productTypeService.getProductType(id);
    } finally {
      this.isLoading = false;
    }

  }

  public async updateProductType(form: NgForm): Promise<void> {
    await this._productTypeService.updateProductType(this.productType);
    this._router.navigate(['product-types']);
  }
}
