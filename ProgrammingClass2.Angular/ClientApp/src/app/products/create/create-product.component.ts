import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Product } from "../../shared/models/product";
import { Category } from "../../shared/models/category";
import { ProductCategory } from "../../shared/models/product-category";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { CategoryService } from "../../shared/services/category.service";
import { ProductCategoryService } from "../../shared/services/product-category.service";
import { ProductService } from "../../shared/services/product.service";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/services/product-type.service";
import { Color } from "../../shared/models/color";
import { ProductColor } from "../../shared/models/product-color";
import { ColorService } from "../../shared/services/color.service";
import { ProductColorService } from "../../shared/services/product-color.service";
import { Currency } from "../../shared/models/currency";
import { ProductCurrency } from "../../shared/models/product-currency";
import { CurrencyService } from "../../shared/services/currency.service";
import { ProductCurrencyService } from "../../shared/services/product-currency.service";

@Component({
  templateUrl: './create-product.component.html'
})
export class CreateProductComponent implements OnInit {
  private readonly _productService: ProductService;
  private readonly _router: Router;
  private readonly _unitOfMeasureService: UnitOfMeasureService;
  private readonly _productTypeService: ProductTypeService;
  private readonly _productCategoryService: ProductCategoryService;
  private readonly _categoryService: CategoryService;
  private readonly _productColorService: ProductColorService;
  private readonly _colorService: ColorService;
  private readonly _productCurrencyService: ProductCurrencyService;
  private readonly _currencyService: CurrencyService;

  // {} nshanakum e datark object.
  public product: Product = {};
  public unitOfMeasures: UnitOfMeasure[] = [];
  public productTypes: ProductType[] = [];
  public categories: Category[] = [];
  public productCategories: ProductCategory[] = [];
  public selectedCategory: number;
  public colors: Color[] = [];
  public productColors: ProductColor[] = [];
  public selectedColor: number;
  public currencies: Currency[] = [];
  public productCurrencies: ProductCurrency[] = [];
  public selectedCurrency: number;
  public isLoading: boolean;

  constructor(
    productService: ProductService,
    router: Router,
    unitOfMeasureService: UnitOfMeasureService,
    productTypeService: ProductTypeService,
    productCategoryService: ProductCategoryService,
    categoryService: CategoryService,
    productColorService: ProductColorService,
    colorService: ColorService,
    productCurrencyService: ProductCurrencyService,
    currencyService: CurrencyService
  ) {
    this._productService = productService;
    this._router = router;
    this._unitOfMeasureService = unitOfMeasureService;
    this._productTypeService = productTypeService;
    this._productCategoryService = productCategoryService;
    this._categoryService = categoryService;
    this._productColorService = productColorService;
    this._colorService = colorService;
    this._productCurrencyService = productCurrencyService;
    this._currencyService = currencyService;
  }

  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;

      this.unitOfMeasures = await this._unitOfMeasureService.getAll();
      this.productTypes = await this._productTypeService.getAll();
      this.categories = await this._categoryService.getAll();
      this.colors = await this._colorService.getAll();
      this.currencies = await this._currencyService.getAll();
    } finally {
      this.isLoading = false;
    }
  }

  public async createProduct(form: NgForm): Promise<void> {
    if (form.valid) {
      try {
        this.isLoading = true;

        await this._productService.createProduct(this.product);
        this._router.navigate(['products']);
      } finally {
        this.isLoading = false;
      }
    }
  }
}
