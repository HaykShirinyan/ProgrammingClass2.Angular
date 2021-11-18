"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ProductTypeListComponent = void 0;
var ProductTypeListComponent = /** @class */ (function () {
    function ProductTypeListComponent(http) {
        this._http = http;
    }
    ProductTypeListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._http.get('api/product-types').subscribe(function (apiProductTypes) {
            _this.productTypes = apiProductTypes;
        });
    };
    return ProductTypeListComponent;
}());
exports.ProductTypeListComponent = ProductTypeListComponent;
//# sourceMappingURL=product-type-list.component.js.map