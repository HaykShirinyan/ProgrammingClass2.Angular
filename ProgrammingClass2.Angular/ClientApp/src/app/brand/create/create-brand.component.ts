import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Brand} from "../../shared/models/brand";
import { BrandService } from "../../shared/services/brand.service";


@Component({
  templateUrl: './create-brand.component.html'
})
export class CreateBrandComponent {
  private readonly _brandService: BrandService;
  private readonly _router: Router;

  public brand: Brand = {};

  constructor(brandService: BrandService, router: Router) {
    this._brandService = brandService;
    this._router = router;
  }

  public async createBrand(form: NgForm): Promise<void> {
    if (form.valid) {
      await this._brandService.createBrand(this.brand);
      this._router.navigate(['brands']);
    }
  }
}
