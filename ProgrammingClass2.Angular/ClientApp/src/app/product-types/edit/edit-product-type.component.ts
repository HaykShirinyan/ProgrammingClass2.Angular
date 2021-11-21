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
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    await this._productTypeService.getAll();
  }

  public async updateProductType(form: NgForm): Promise<void> {
    await this._productTypeService.getAll();
    this._router.navigate(['product-types']);
  }
}
