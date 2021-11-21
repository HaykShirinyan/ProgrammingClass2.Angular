// import nman e C#-i meji using-nerin.
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Product } from "../../shared/models/product";
import { ProductService } from "../../shared/services/product.service";

// Es mer ProductListComponent pti anpayman avelacnenq AppModule class-i mej

@Component({
  templateUrl: './product-list.component.html'
})
// export nshanakum e public. Nuynn e inch vor C#-i public keyword-e.
export class ProductListComponent implements OnInit {
  private readonly _productService: ProductService;

  // [] nshanakum e list.
  public products: Product[];
  public isLoading: boolean;

  constructor(productService: ProductService) {
    this._productService = productService;
  }

  // ngOnInit kanchvum e erb mer component-e nor bacvum e.
  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;

      this.products = await this._productService.getProducts();
    } finally {
      this.isLoading = false;
    }
  }

  public spinnerHidden(): void {
    this.isLoading = false;
  }
}
