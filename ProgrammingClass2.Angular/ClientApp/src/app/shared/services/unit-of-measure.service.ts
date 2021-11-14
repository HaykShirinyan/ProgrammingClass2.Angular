import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UnitOfMeasure } from "../models/unit-of-measure";

@Injectable({
  providedIn: 'root'
})
export class UnitOfMeasureService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getAll(): Promise<UnitOfMeasure[]> {
    return this._http
      .get<UnitOfMeasure[]>('api/unit-of-measures')
      .toPromise();
  }

  public create(unitOfMeasure: UnitOfMeasure): Promise<UnitOfMeasure> {
    return this._http
      .post<UnitOfMeasure>('api/unit-of-measures', unitOfMeasure)
      .toPromise();
  }
}
