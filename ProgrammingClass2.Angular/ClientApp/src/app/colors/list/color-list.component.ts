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

  constructor(colorService: ColorService) {
    this._colorService = colorService;
  }

  public async ngOnInit(): Promise<void> {
    this.colors = await this._colorService.getColors();
  }
}
