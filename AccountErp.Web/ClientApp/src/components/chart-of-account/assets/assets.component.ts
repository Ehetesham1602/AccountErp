import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-assets',
  templateUrl: './assets.component.html',
  styleUrls: ['./assets.component.css']
})
export class AssetsComponent implements OnInit {
  @Output() openAddAccountModal = new EventEmitter();
  @Output() closeAddAccountModal = new EventEmitter();
  accType;
  constructor() { }

  ngOnInit() {
  }

}
