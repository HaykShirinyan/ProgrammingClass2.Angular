import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Category } from "../../shared/models/category";
import { Product } from "../../shared/models/product";
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
  templateUrl: './edit-product.component.html'
})
export class EditProductComponent implements OnInit {
  private readonly _productService: ProductService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;
  private readonly _unitOfMeasureService: UnitOfMeasureService;
  private readonly _productTypeService: ProductTypeService;
  private readonly _productCategoryService: ProductCategoryService;
  private readonly _categoryService: CategoryService;
  private readonly _productColorService: ProductColorService;
  private readonly _colorService: ColorService;
  private readonly _productCurrencyService: ProductCurrencyService;
  private readonly _currencyService: CurrencyService;

  public product: Product;
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

  constructor(
    productService: ProductService,
    activeRoute: ActivatedRoute,
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
    this._activeRoute = activeRoute;
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
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);
    this.product = await this._productService.getProduct(id);
    this.unitOfMeasures = await this._unitOfMeasureService.getAll();
    this.productTypes = await this._productTypeService.getAll();
    this.categories = await this._categoryService.getAll();
    this.productCategories = await this._productCategoryService.getAll(id);
    this.colors = await this._colorService.getAll();
    this.productColors = await this._productColorService.getAll(id);
    this.currencies = await this._currencyService.getAll();
    this.productCurrencies = await this._productCategoryService.getAll(id);
  }

  public async updateProduct(form: NgForm): Promise<void> {
    if (form.valid) {
      await this._productService.updateProduct(this.product);
      this._router.navigate(['products']);
    }
  }

  public async addCategory(): Promise<void> {
    if (this.selectedCategory) {
      await this._productCategoryService.add({
        productId: this.product.id,
        categoryId: this.selectedCategory
      });

      this.productCategories = await this._productCategoryService.getAll(this.product.id);
      this.selectedCategory = null;
    }
  }

  public async deleteCategory(categoryId: number): Promise<void> {
    await this._productCategoryService.delete({
      productId: this.product.id,
      categoryId: categoryId
    });

    this.productCategories = await this._productCategoryService.getAll(this.product.id);
  }

  public async addColor(): Promise<void> {
    if (this.selectedColor) {
      await this._productColorService.add({
        productId: this.product.id,
        colorId: this.selectedColor
      });

      this.productColors = await this._productColorService.getAll(this.product.id);
      this.selectedColor = null;
    }
  }

  public async deleteColor(colorId: number): Promise<void> {
    await this._productColorService.delete({
      productId: this.product.id,
      colorId: colorId
    });

    this.productColors = await this._productColorService.getAll(this.product.id);
  }

  public async addCurrency(): Promise<void> {
    if (this.selectedCurrency) {
      await this._productCurrencyService.add({
        productId: this.product.id,
        currencyId: this.selectedCurrency
      });

      this.productCurrencies = await this._productCurrencyService.getAll(this.product.id);
      this.selectedCurrency = null;
    }
  }

  public async deleteCurrency(currencyId: number): Promise<void> {
    await this._productCurrencyService.delete({
      productId: this.product.id,
      currencyId: currencyId
    });

    this.productCurrencies = await this._productCurrencyService.getAll(this.product.id);
  }
}
