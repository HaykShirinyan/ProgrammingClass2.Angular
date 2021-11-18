"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CurrencyService = void 0;
var CurrencyService = /** @class */ (function () {
    function CurrencyService(http) {
        this._http = http;
    }
    CurrencyService.prototype.getCurrencies = function () {
        return this._http
            .get('api/currencies')
            .toPromise();
    };
    return CurrencyService;
}());
exports.CurrencyService = CurrencyService;
//# sourceMappingURL=currency.service.js.map