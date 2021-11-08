"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ProductTypeService = void 0;
var ProductTypeService = /** @class */ (function () {
    function ProductTypeService(http) {
        this._http = http;
    }
    ProductTypeService.prototype.getProductType = function () {
        return this._http.get('api/product-types').toPromise();
    };
    return ProductTypeService;
}());
exports.ProductTypeService = ProductTypeService;
//# sourceMappingURL=productType.service.js.map