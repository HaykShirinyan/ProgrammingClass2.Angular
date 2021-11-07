import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ProductType } from "../../shared/models/productType";
import { ProductTypeService } from "../../shared/services/productType.service";

@Component({
  templateUrl: './edit-productType.component.html'
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

    this.productType = await this._productTypeService.getProductType(id);
  }

  public async updateProductType(form: NgForm): Promise<void> {
    await this._productTypeService.updateProductType(this.productType);
    this._router.navigate(['productTypes']);
  }
}
