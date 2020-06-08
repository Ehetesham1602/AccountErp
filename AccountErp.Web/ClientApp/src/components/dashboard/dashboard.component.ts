import { Component, OnInit } from '@angular/core';

declare var appConfig: any;

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html'
})

export class DashboardComponent implements OnInit {

    ngOnInit() {
        setTimeout(() => {
            appConfig.initKTDefaults();
        }, 500);
    }
}

