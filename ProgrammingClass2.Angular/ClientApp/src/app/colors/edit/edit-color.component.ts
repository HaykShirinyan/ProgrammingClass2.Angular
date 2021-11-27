import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Color } from "../../shared/models/color";
import { ColorService } from "../../shared/services/color.service";

@Component({
  templateUrl: './edit-color.component.html'
})
export class EditColorComponent implements OnInit {
  private readonly _colorService: ColorService;
  private readonly _activeRoute: ActivatedRoute;
  private readonly _router: Router;

  public color: Color;
  public isLoading: boolean;

  constructor(
    colorService: ColorService,
    activeRoute: ActivatedRoute,
    router: Router
  ) {
    this._colorService = colorService;
    this._activeRoute = activeRoute;
    this._router = router;
  }

  public async ngOnInit(): Promise<void> {
    let idParameter = this._activeRoute.snapshot.paramMap.get('id');
    let id = parseInt(idParameter);

    try {
      this.isLoading = true;

      await this._colorService.getAll();
    } finally {
      this.isLoading = false;
    }
  }

  public async updateColor(form: NgForm): Promise<void> {
    try {
      this.isLoading = true;

      await this._colorService.getAll();
      this._router.navigate(['colors']);
    } finally {
      this.isLoading = false;
    }
  }
}
