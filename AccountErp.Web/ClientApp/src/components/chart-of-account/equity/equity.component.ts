import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-equity',
  templateUrl: './equity.component.html',
  styleUrls: ['./equity.component.css']
})
export class EquityComponent implements OnInit {
  @Output() openAddAccountModal = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

}
