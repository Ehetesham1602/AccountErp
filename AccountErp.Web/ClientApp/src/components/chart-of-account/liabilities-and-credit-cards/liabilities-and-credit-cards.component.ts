import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-liabilities-and-credit-cards',
  templateUrl: './liabilities-and-credit-cards.component.html',
  styleUrls: ['./liabilities-and-credit-cards.component.css']
})
export class LiabilitiesAndCreditCardsComponent implements OnInit {
  @Output() openAddAccountModal = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

}
