import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Brand } from "../../shared/models/brand";
import { BrandService } from "../../shared/services/brand.service";

@Component({
  templateUrl: './edit-brand.component.html'
})
export class EditBrandComponent implements OnInit {
  private readonly _brandService: BrandService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;

  public brand: Brand;

  constructor(
    brandService: BrandService,
    activeRoute: ActivatedRoute,
    router: Router
  ) {
    this._brandService = brandService;
    this._activeRoute = activeRoute;
    this._router = router;
  }

  public async ngOnInit(): Promise<void> {
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    this.brand = await this._brandService.getBrand(id);
  }

  public async updateBrand(form: NgForm): Promise<void> {
    await this._brandService.updateBrand(this.brand);
    this._router.navigate(['brands']);
  }
}
