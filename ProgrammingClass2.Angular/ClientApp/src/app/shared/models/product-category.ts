import { Category } from "./category";
import { Product } from "./product";

export interface ProductCategory {
  productId?: number;
  product?: Product;

  categoryId?: number;
  category?: Category;
}
