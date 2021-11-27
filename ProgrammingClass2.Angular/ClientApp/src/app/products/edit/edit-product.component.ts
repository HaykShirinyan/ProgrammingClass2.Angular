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
import { BrandService } from "../../shared/services/brand.service";
import { ProductBrand } from "../../shared/models/product-brand";
import { Brand } from "../../shared/models/brand";
import { ProductBrandService } from "../../shared/services/product-brand.service";

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
  private readonly _brandService: BrandService;
  private readonly _productBrandService: ProductBrandService;

  public product: Product;
  public unitOfMeasures: UnitOfMeasure[] = [];
  public currencies: Currency[] = [];
  public productTypes: ProductType[] = [];
  public productBrand: ProductBrand[] = [];

  public categories: Category[] = [];
  public productCategories: ProductCategory[] = [];
  public selectedCategory: number;

  public brands: Brand[] = [];
  public productBrands: ProductBrand[] = [];
  public selectedBrand: number;

  public isLoading: boolean;

  constructor(
    productService: ProductService,
    activeRoute: ActivatedRoute,
    router: Router,
    unitOfMeasureService: UnitOfMeasureService,
    currencyService: CurrencyService,
    productTypeService: ProductTypeService,
    productCategoryService: ProductCategoryService,
    categoryService: CategoryService,
    brandService: BrandService,
    productBrandService: ProductBrandService
  ) {
    this._productService = productService;
    this._activeRoute = activeRoute;
    this._router = router;
    this._unitOfMeasureService = unitOfMeasureService;
    this._currencyService = currencyService;
    this._productTypeService = productTypeService;
    this._productCategoryService = productCategoryService;
    this._categoryService = categoryService;
    this._brandService = brandService;
    this._productBrandService = productBrandService;
  }

  public async ngOnInit(): Promise<void> {
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    try {
      this.isLoading = true;

      this.product = await this._productService.getProduct(id);
      this.unitOfMeasures = await this._unitOfMeasureService.getAll();

      this.categories = await this._categoryService.getAll();
      this.productCategories = await this._productCategoryService.getAll(id);
    } finally {
      this.isLoading = false
    }    
    this.product = await this._productService.getProduct(id);
    this.unitOfMeasures = await this._unitOfMeasureService.getAll();
    this.currencies = await this._currencyService.getCurrencies();
    this.productTypes = await this._productTypeService.getProductTypes();

    this.categories = await this._categoryService.getAll();
    this.productCategories = await this._productCategoryService.getAll(id);

    this.brands = await this._brandService.getBrands();
    this.productBrands = await this._productBrandService.getAll(id);
  }

  public async updateProduct(form: NgForm): Promise<void> {
    if (form.valid) {
      try {
        this.isLoading = true;

        await this._productService.updateProduct(this.product);
        this._router.navigate(['products']);
      } finally {
        this.isLoading = false;
      }      
    }
  }

  public async addCategory(): Promise<void> {
    if (this.selectedCategory) {
      try {
        this.isLoading = true;

        await this._productCategoryService.add({
          productId: this.product.id,
          categoryId: this.selectedCategory
        });

        this.productCategories = await this._productCategoryService.getAll(this.product.id);
        this.selectedCategory = null;
      } finally {
        this.isLoading = false;
      }      
    }
  }

  public async deleteCategory(categoryId: number): Promise<void> {
    try {
      this.isLoading = true;

      await this._productCategoryService.delete({
        productId: this.product.id,
        categoryId: categoryId
      });

      this.productCategories = await this._productCategoryService.getAll(this.product.id);
    } finally {
      this.isLoading = false;
    }
  }

  public async addBrand(): Promise<void> {
    if (this.selectedBrand) {
      await this._productBrandService.add({
        productId: this.product.id,
        brandId: this.selectedBrand
      });

      this.productBrands = await this._productBrandService.getAll(this.product.id);
      this.selectedBrand = null;
    }
  }

  public async deleteBrand(brandId: number): Promise<void> {
    await this._productBrandService.delete({
      productId: this.product.id,
      brandId: brandId
    });

    this.productBrands = await this._productBrandService.getAll(this.product.id);
  }
}

