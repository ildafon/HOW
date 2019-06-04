"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var RequestObject = /** @class */ (function () {
    function RequestObject(pageNumber, pageSize, term, related) {
        if (pageNumber === void 0) { pageNumber = 1; }
        if (pageSize === void 0) { pageSize = 5; }
        if (term === void 0) { term = ''; }
        if (related === void 0) { related = true; }
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
        this.term = term;
        this.related = related;
    }
    return RequestObject;
}());
exports.RequestObject = RequestObject;
//# sourceMappingURL=requestObject.js.map