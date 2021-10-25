// import nman e C#-i meji using-nerin.
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Product } from "../../shared/models/product";

// Es mer ProductListComponent pti anpayman avelacnenq AppModule class-i mej

@Component({
  templateUrl: './product-list.component.html'
})
// export nshanakum e public. Nuynn e inch vor C#-i public keyword-e.
export class ProductListComponent implements OnInit {
  private readonly _http: HttpClient;

  // [] nshanakum e list.
  public products: Product[];

  constructor(http: HttpClient) {
    this._http = http;
  }

  // ngOnInit kanchvum e erb mer component-e nor bacvum e.
  public ngOnInit(): void {
    // HttpClient service-i mijocov kapnvum enq mer API het.
    // subscribe function-e kanchvum e erb menq tvyalnere API stanum enq.
    this._http.get<Product[]>('api/products').subscribe(apiProducts => {
      this.products = apiProducts
    });
  }
}
