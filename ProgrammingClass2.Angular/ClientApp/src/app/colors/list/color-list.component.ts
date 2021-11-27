import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Color } from "../../shared/models/color";
import { ColorService } from "../../shared/services/color.service";

type NewType = Promise<void>;

@Component({
  templateUrl: './color-list.component.html'
})
export class ColorListComponent implements OnInit {
  private readonly _colorService: ColorService;

  public colors: Color[];
  public isLoading: boolean;

  constructor(colorService: ColorService) {
    this._colorService = colorService;
  }

  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;

      this.colors = await this._colorService.getAll();
    } finally {
      this.isLoading = false;
    }
  }

  public spinnerHidden(): void {
    this.isLoading = false;
  }
}
