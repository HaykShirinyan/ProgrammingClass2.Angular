"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ProductTypeService = void 0;
var ProductTypeService = /** @class */ (function () {
    function ProductTypeService(http) {
        this._http = http;
    }
    ProductTypeService.prototype.getProductTypes = function () {
        return this._http
            .get('api/product-types')
            .toPromise();
    };
    ProductTypeService.prototype.getProductType = function (id) {
        return this._http
            .get('api/product-types' + id)
            .toPromise();
    };
    ProductTypeService.prototype.createProductType = function (productType) {
        return this
            ._http.post('api/product-types', productType)
            .toPromise();
    };
    ProductTypeService.prototype.updateProductType = function (productType) {
        return this._http
            .put('api/product-types' + productType.id, productType)
            .toPromise();
    };
    return ProductTypeService;
}());
exports.ProductTypeService = ProductTypeService;
//# sourceMappingURL=product-type.service.js.map