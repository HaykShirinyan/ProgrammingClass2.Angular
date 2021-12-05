import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Product } from "../../shared/models/product";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { ProductService } from "../../shared/services/product.service";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";

@Component({
  templateUrl: './create-product.component.html'
})
export class CreateProductComponent implements OnInit {
  private readonly _productService: ProductService;
  private readonly _router: Router;
  private readonly _unitOfMeasureService: UnitOfMeasureService;

  // {} nshanakum e datark object.
  public product: Product = {};
  public unitOfMeasures: UnitOfMeasure[] = [];

  constructor(
    productService: ProductService,
    router: Router,
    unitOfMeasureService: UnitOfMeasureService
  ) {
    this._productService = productService;
    this._router = router;
    this._unitOfMeasureService = unitOfMeasureService;
  }

  public async ngOnInit(): Promise<void> {
    this.unitOfMeasures = await this._unitOfMeasureService.getAll();
  }

  public async createProduct(form: NgForm): Promise<void> {
    if (form.valid) {
      await this._productService.createProduct(this.product);
      this._router.navigate(['products']);
    }
  }

  public unitOfMeasureSelected(value: number): void {
    if (value) {
      this.product.unitOfMeasure = {
        id: value
      };
    } else {
      this.product.unitOfMeasure = null;
    }
  }
}
