import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Product } from "../../shared/models/product";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { ProductType } from "../../shared/models/product-type";
import { ProductService } from "../../shared/services/product.service";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";
import { ProductTypeService } from "../../shared/services/product-type.service";

@Component({
  templateUrl: './edit-product.component.html'
})
export class EditProductComponent implements OnInit {
  private readonly _productService: ProductService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;
  private readonly _unitOfMeasureService: UnitOfMeasureService;
  private readonly _productTypeService: ProductTypeService;

  public product: Product;
  public unitOfMeasures: UnitOfMeasure[] = [];
  public productTypes: ProductType[] = [];

  constructor(
    productService: ProductService,
    activeRoute: ActivatedRoute,
    router: Router,
    unitOfMeasureService: UnitOfMeasureService,
    productTypeService: ProductTypeService
  ) {
    this._productService = productService;
    this._activeRoute = activeRoute;
    this._router = router;
    this._unitOfMeasureService = unitOfMeasureService;
    this._productTypeService = productTypeService;
  }

  public async ngOnInit(): Promise<void> {
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    this.product = await this._productService.getProduct(id);
    this.unitOfMeasures = await this._unitOfMeasureService.getAll();
    this.productTypes = await this._productTypeService.getAll();
  }

  public async updateProduct(form: NgForm): Promise<void> {
    await this._productService.updateProduct(this.product);
    this._router.navigate(['products']);
  }
}
