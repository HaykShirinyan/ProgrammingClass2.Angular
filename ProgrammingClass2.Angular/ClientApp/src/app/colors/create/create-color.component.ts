import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Color } from "../../shared/models/color";
import { ColorService } from "../../shared/services/color.service";

@Component({
  templateUrl: './create-color.component.html'
})
export class CreateColorComponent {
  private readonly _colorService: ColorService;
  private readonly _router: Router;

  public color: Color = {};
  public isLoading: boolean;

  constructor(colorService: ColorService, router: Router) {
    this._colorService = colorService;
    this._router = router;
  }

  public async createColor(form: NgForm): Promise<void> {
    if (form.valid) {
      try {
        this.isLoading = true;

        await this._colorService.getAll();
        this._router.navigate(['colors']);
      } finally {
        this.isLoading = false;
      }
    }
  }
}
