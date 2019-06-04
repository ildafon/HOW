"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var RequestObject = /** @class */ (function () {
    function RequestObject(pageNumber, pageSize, pageTotal, term, related, visitedId) {
        if (pageNumber === void 0) { pageNumber = 1; }
        if (pageSize === void 0) { pageSize = 5; }
        if (term === void 0) { term = ''; }
        if (related === void 0) { related = true; }
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
        this.pageTotal = pageTotal;
        this.term = term;
        this.related = related;
        this.visitedId = visitedId;
    }
    return RequestObject;
}());
exports.RequestObject = RequestObject;
//# sourceMappingURL=requestObject.js.map