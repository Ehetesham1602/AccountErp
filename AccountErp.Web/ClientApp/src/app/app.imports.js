"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/common/http");
var common_1 = require("@angular/common");
var animations_1 = require("@angular/platform-browser/animations");
var ng_bootstrap_1 = require("@ng-bootstrap/ng-bootstrap");
var angular_datatables_1 = require("angular-datatables");
var ngx_toastr_1 = require("ngx-toastr");
var ng_block_ui_1 = require("ng-block-ui");
var ngx_mask_1 = require("ngx-mask");
var app_routing_1 = require("./app.routing");
var ng_fullcalendar_1 = require("ng-fullcalendar");
var ngx_select_dropdown_1 = require("ngx-select-dropdown");
exports.appImports = [
    platform_browser_1.BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    http_1.HttpClientModule,
    forms_1.FormsModule,
    ng_bootstrap_1.NgbModule,
    common_1.CommonModule,
    animations_1.BrowserAnimationsModule,
    angular_datatables_1.DataTablesModule,
    ngx_toastr_1.ToastrModule.forRoot(),
    ngx_mask_1.NgxMaskModule.forRoot(),
    ng_block_ui_1.BlockUIModule.forRoot({ message: 'Loading...' }),
    app_routing_1.appRouting,
    ng_fullcalendar_1.FullCalendarModule,
    ngx_select_dropdown_1.SelectDropDownModule,
];
//# sourceMappingURL=app.imports.js.map