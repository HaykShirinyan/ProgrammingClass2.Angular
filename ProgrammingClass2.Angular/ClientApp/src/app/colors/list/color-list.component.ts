import { HttpClient } from "@angular/common/http";
import { Type } from "@angular/compiler";
import { Component, OnInit } from "@angular/core";
import { Color } from "../../shared/models/color";
import { ColorService } from "../../shared/services/color.service";



@Component({
  templateUrl: './color-list.component.html'
})

export class ColorListComponent implements OnInit {
  private readonly _currencyService: ColorService;

  public colors: Color[];
  public isLoading: boolean;
  private _colorService: ColorService;

  constructor(colorService: ColorService) {
    this._colorService = colorService;
  }

  public async ngOnInit(): Promise<void> {
    try {
      this.isLoading = true;
      this.colors = await this._colorService.getColors();
    } finally {
      this.isLoading = false;
    }
  }

  public spinnerHidden(): void {
  this.isLoading = false;

  }
}
