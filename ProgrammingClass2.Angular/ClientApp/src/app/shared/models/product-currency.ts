import { Currency } from "./currency";
import { Product } from "./product";

export interface ProductCurrency {
  productId?: number;
  product?: Product;

  currencyId?: number;
  currency?: Currency;
}
