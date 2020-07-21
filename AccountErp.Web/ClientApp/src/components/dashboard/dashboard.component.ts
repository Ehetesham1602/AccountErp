import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';

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

    // Line chart
    lineChartData: ChartDataSets[] = [
        { data: [85, 72, 78, 75, 77, 75], label: 'Yearly profit' },
      
      ];
    
      lineChartLabels: Label[] = ['January', 'February', 'March', 'April', 'May', 'June'];
    
      lineChartOptions = {
        responsive: true,
      };
    
      lineChartColors: Color[] = [
        {
          borderColor: 'rgb(2, 105, 2)',
          backgroundColor: '#0abb87',
        },
      ];
    
      lineChartLegend = true;
      lineChartPlugins = [];
      lineChartType = 'line';

    // Bar chart 

    barChartData: ChartDataSets[] = [
        { data: [85, 72, 78, 75, 77, 75], label: 'Sales' },
        { data: [75, 77, 75, 78, 72, 85], label: 'Expense' },
      ];
    
      barChartLabels: Label[] = ['January', 'February', 'March', 'April', 'May', 'June'];
    
      barChartOptions = {
        responsive: true,
      };
    
      barChartColors: Color[] = [
        {
          borderColor: 'rgb(2, 105, 2)',
          backgroundColor: '#0abb87',
        },
      ];
    
      barChartLegend = true;
      barChartPlugins = [];
      barChartType = 'bar';

    //   pie chart
    pieChartData: ChartDataSets[] = [
        { data: [185, 72, 78, 75, 77, 75], label: 'Sales' },
       
      ];
    
      pieChartLabels: Label[] = ['January', 'February', 'March', 'April', 'May', 'June'];
    
      pieChartOptions = {
        responsive: true,
      };
    
    //   pieChartColors: Color[] = [
    //     {
    //       borderColor: 'rgb(2, 105, 2)',
    //       backgroundColor: '#0abb87',
    //     },
    //   ];
    
      pieChartLegend = true;
      pieChartPlugins = [];
      pieChartType = 'pie';


      
}

