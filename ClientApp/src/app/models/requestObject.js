"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var RequestObject = /** @class */ (function () {
    function RequestObject(pageNumber, pageSize, related, pageTotal, term, visitedId) {
        if (pageNumber === void 0) { pageNumber = 1; }
        if (pageSize === void 0) { pageSize = 5; }
        if (related === void 0) { related = true; }
        if (term === void 0) { term = ''; }
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
        this.related = related;
        this.pageTotal = pageTotal;
        this.term = term;
        this.visitedId = visitedId;
    }
    return RequestObject;
}());
exports.RequestObject = RequestObject;
//# sourceMappingURL=requestObject.js.map