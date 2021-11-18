import { UnitOfMeasure } from "./unit-of-measure";

export interface Product {
  // ? nshanakum e Product object sarqeluc partadir che ? nshanov property-nerin voreve ban nshanakel
  id?: number;
  name?: string;
  description?: string;
  quantity?: number;
  unitPrice?: number;

  unitOfMeasureId?: number;
  unitOfMeasure?: UnitOfMeasure;
}
