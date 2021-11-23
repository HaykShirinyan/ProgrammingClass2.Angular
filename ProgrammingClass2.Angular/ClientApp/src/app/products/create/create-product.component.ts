import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Product } from "../../shared/models/product";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { ProductType } from "../../shared/models/productType";
import { ProductService } from "../../shared/services/product.service";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";
import { ProductTypeService } from "../../shared/services/productType.service";

@Component({
  templateUrl: './create-product.component.html'
})
export class CreateProductComponent implements OnInit {
  private readonly _productService: ProductService;
  private readonly _router: Router;
  private readonly _unitOfMeasureService: UnitOfMeasureService;
  private readonly _productTypeService: ProductTypeService;


  // {} nshanakum e datark object.
  public product: Product = {};
  public unitOfMeasures: UnitOfMeasure[] = [];
  public productTypes: ProductType[] = [];

  constructor(
    productService: ProductService,
    router: Router,
    unitOfMeasureService: UnitOfMeasureService,
    productTypeService: ProductTypeService
  ) {
     
    this._productService = productService;
    this._router = router;
      this._unitOfMeasureService = unitOfMeasureService;
      this._productTypeService = productTypeService;
  }

  public async ngOnInit(): Promise<void> {
    this.unitOfMeasures = await this._unitOfMeasureService.getAll();
    this.productTypes = await this._productTypeService.getProductType();
  }

  
  public async createProduct(form: NgForm): Promise<void> {
    if (form.valid) {
      await this._productService.createProduct(this.product);
      this._router.navigate(['products']);
    }
  }
}
