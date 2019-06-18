"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var paging_service_1 = require("./paging.service");
function PagingServiceFactory() {
    return function (localStorage, prefix) {
        return new paging_service_1.PagingService(localStorage, prefix);
    };
}
exports.PagingServiceFactory = PagingServiceFactory;
//# sourceMappingURL=paging-service-factory.js.map