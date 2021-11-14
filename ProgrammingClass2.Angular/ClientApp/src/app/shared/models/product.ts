import { Currency } from "./currency";
import { ProductType } from "./product-type";
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

  currencyId?: number;
  currency?: Currency;

  productTypeId?: number;
  productType?: ProductType;
}
