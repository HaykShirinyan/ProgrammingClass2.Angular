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

  public async getAll(): Promise<Color[]> {
    return await this._http
      .get<Color[]>('api/colors')
      .toPromise();
  }
}
