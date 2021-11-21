import { Brand } from "./brand";
import { Product } from "./product";

export interface ProductBrand {
  productId?: number;
  product?: Product;

  brandId?: number;
  brand?: Brand;
}
