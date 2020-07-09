import { Component, OnInit, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-chart-of-accounts',
  templateUrl: './chart-of-accounts.component.html',
  styleUrls: ['./chart-of-accounts.component.css']
})
export class ChartOfAccountsComponent implements OnInit {
  modalReference: any;
  accType;
  constructor(private modalService: NgbModal,) { }

  ngOnInit() {
  }

  openAddAccountModal(content: any,accType){
    debugger;
    this.accType=accType;
    this.modalReference = this.modalService.open(content,
      {
          backdrop: 'static',
          keyboard: false,
          size: 'lg'
      });
  }

  closeAddAccountModal() {
    //this.updateTotalAmount();
    this.modalReference.close();
}
}
