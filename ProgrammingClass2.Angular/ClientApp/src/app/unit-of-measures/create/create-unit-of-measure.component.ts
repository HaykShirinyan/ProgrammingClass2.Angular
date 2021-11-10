import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";

@Component({
  templateUrl: './create-unit-of-measure.component.html'
})
export class CreateUnitOfMeasureComponent {
  private readonly _unitOfMeasureService: UnitOfMeasureService;
  private readonly _router: Router;

  public model: UnitOfMeasure = {};

  constructor(unitOfMeasureService: UnitOfMeasureService, router: Router) {
    this._unitOfMeasureService = unitOfMeasureService;
    this._router = router;
  }

  public async create(form: NgForm): Promise<void> {
    if (form.valid) {
      await this._unitOfMeasureService.create(this.model);
      this._router.navigate(['unit-of-measures']);
    }
  }
}
