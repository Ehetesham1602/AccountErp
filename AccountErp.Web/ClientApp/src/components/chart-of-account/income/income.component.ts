import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-income',
  templateUrl: './income.component.html',
  styleUrls: ['./income.component.css']
})
export class IncomeComponent implements OnInit {
  @Output() openAddAccountModal = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

}
