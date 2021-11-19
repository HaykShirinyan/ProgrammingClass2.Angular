import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Currency } from "../../shared/models/currency";
import { Category } from "../../shared/models/category";
import { Product } from "../../shared/models/product";
import { ProductType } from "../../shared/models/product-type";
import { ProductCategory } from "../../shared/models/product-category";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { CurrencyService } from "../../shared/services/currency.service";
import { ProductTypeService } from "../../shared/services/product-type.service";
import { CategoryService } from "../../shared/services/category.service";
import { ProductCategoryService } from "../../shared/services/product-category.service";
import { ProductService } from "../../shared/services/product.service";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";

@Component({
  templateUrl: './edit-product.component.html'
})
export class EditProductComponent implements OnInit {
  private readonly _productService: ProductService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;
  private readonly _unitOfMeasureService: UnitOfMeasureService;
  private readonly _currencyService: CurrencyService;
  private readonly _productTypeService: ProductTypeService;
  private readonly _productCategoryService: ProductCategoryService;
  private readonly _categoryService: CategoryService;

  public product: Product;
  public unitOfMeasures: UnitOfMeasure[] = [];
  public currencies: Currency[] = [];
  public productTypes: ProductType[] = [];

  public categories: Category[] = [];
  public productCategories: ProductCategory[] = [];
  public selectedCategory: number;

  constructor(
    productService: ProductService,
    activeRoute: ActivatedRoute,
    router: Router,
    unitOfMeasureService: UnitOfMeasureService,
    currencyService: CurrencyService,
    productTypeService: ProductTypeService
    unitOfMeasureService: UnitOfMeasureService,
    productCategoryService: ProductCategoryService,
    categoryService: CategoryService
  ) {
    this._productService = productService;
    this._activeRoute = activeRoute;
    this._router = router;
    this._unitOfMeasureService = unitOfMeasureService;
    this._currencyService = currencyService;
    this._productTypeService = productTypeService;
    this._productCategoryService = productCategoryService;
    this._categoryService = categoryService;
  }

  public async ngOnInit(): Promise<void> {
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    this.product = await this._productService.getProduct(id);
    this.unitOfMeasures = await this._unitOfMeasureService.getAll();
    this.currencies = await this._currencyService.getCurrencies();
    this.productTypes = await this._productTypeService.getProductTypes();
     
    this.categories = await this._categoryService.getAll();
    this.productCategories = await this._productCategoryService.getAll(id);
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
}
