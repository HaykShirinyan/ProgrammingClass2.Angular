import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Category } from "../../shared/models/category";
import { Product } from "../../shared/models/product";
import { ProductCategory } from "../../shared/models/product-category";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { ProductType } from "../../shared/models/productType";
import { CategoryService } from "../../shared/services/category.service";
import { ProductCategoryService } from "../../shared/services/product-category.service";
import { ProductService } from "../../shared/services/product.service";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";
import { ProductTypeService } from "../../shared/services/productType.service";

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

  public product: Product;
  public unitOfMeasures: UnitOfMeasure[] = [];
  public productTypes: ProductType[] = [];

  public categories: Category[] = [];
  public productCategories: ProductCategory[] = [];
  public selectedCategory: number;

  constructor(
    productService: ProductService,
    activeRoute: ActivatedRoute,
    router: Router, productTypeService: ProductTypeService,
    unitOfMeasureService: UnitOfMeasureService
    router: Router,
    unitOfMeasureService: UnitOfMeasureService,
    productCategoryService: ProductCategoryService,
    categoryService: CategoryService
  ) {
    this._productService = productService;
    this._activeRoute = activeRoute;
    this._router = router;
    this._productTypeService = productTypeService;
    this._unitOfMeasureService = unitOfMeasureService;
    this._productCategoryService = productCategoryService;
    this._categoryService = categoryService;
  }

  public async ngOnInit(): Promise<void> {
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    this.product = await this._productService.getProduct(id);
    this.productTypes = await this._productTypeService.getProductType();
    this.unitOfMeasures = await this._unitOfMeasureService.getAll();
     
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
