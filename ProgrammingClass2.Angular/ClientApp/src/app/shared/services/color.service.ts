import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Color } from "../models/color";

@Injectable({
  providedIn: 'root'
})
export class ColorService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getColors(): Promise<Color[]> {
    return this._http
      .get<Color[]>('api/colors')
      .toPromise();
  }

  public getColor(id: number): Promise<Color> {
    return this._http
      .get<Color>('api/colors/' + id)
      .toPromise();
  }

  public createColor(color: Color): Promise<Color> {
    return this._http
      .post<Color>('api/colors', color)
      .toPromise();
  }

  public updateColor(color: Color): Promise<Color> {
    return this._http
      .put<Color>('api/colors/' + color.id, color)
      .toPromise();
  }
}
