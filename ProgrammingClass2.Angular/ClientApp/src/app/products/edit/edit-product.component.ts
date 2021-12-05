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

@Component({
  templateUrl: './edit-product.component.html'
})
export class EditProductComponent implements OnInit {
  private readonly _productService: ProductService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;
  private readonly _unitOfMeasureService: UnitOfMeasureService;
  private readonly _productCategoryService: ProductCategoryService;
  private readonly _categoryService: CategoryService;

  public product: Product;
  public unitOfMeasures: UnitOfMeasure[] = [];

  public categories: Category[] = [];
  public productCategories: ProductCategory[] = [];
  public selectedCategory: number;

  public isLoading: boolean;

  constructor(
    productService: ProductService,
    activeRoute: ActivatedRoute,
    router: Router,
    unitOfMeasureService: UnitOfMeasureService,
    productCategoryService: ProductCategoryService,
    categoryService: CategoryService
  ) {
    this._productService = productService;
    this._activeRoute = activeRoute;
    this._router = router;
    this._unitOfMeasureService = unitOfMeasureService;
    this._productCategoryService = productCategoryService;
    this._categoryService = categoryService;
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
          product: {
            id: this.product.id
          },
          category: {
            id: this.selectedCategory
          }
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
        product: {
          id: this.product.id
        },
        category: {
          id: categoryId
        }
      });

      this.productCategories = await this._productCategoryService.getAll(this.product.id);
    } finally {
      this.isLoading = false;
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
