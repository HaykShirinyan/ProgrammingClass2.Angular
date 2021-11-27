import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";

type NewType = Promise<void>;

@Component({
  templateUrl: './unit-of-measure-list.component.html'
})
export class UnitOfMeasureListComponent implements OnInit {
  private readonly _unitOfMeasureService: UnitOfMeasureService;

  public unitOfMeasure: UnitOfMeasure[];
  public isLoading: boolean;

  constructor(unitOfMeasureService: UnitOfMeasureService) {
    this._unitOfMeasureService = unitOfMeasureService;
  }

  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;

      this.unitOfMeasure = await this._unitOfMeasureService.getAll();
    } finally {
      this.isLoading = false;
    }
  }

  public spinnerHidden(): void {
    this.isLoading = false;
  }
}
