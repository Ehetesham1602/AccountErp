import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit {
  @Output() openAddAccountModal = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

}
