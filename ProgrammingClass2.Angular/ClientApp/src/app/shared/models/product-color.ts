import { Color } from "./color";
import { Product } from "./product";

export interface ProductColor {
  productId?: number;
  product?: Product;

  colorId?: number;
  color?: Color;
}
