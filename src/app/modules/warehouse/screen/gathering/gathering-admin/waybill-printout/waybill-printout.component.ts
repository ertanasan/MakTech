import {Component, Input, OnInit} from '@angular/core';
import {GatheringDetail} from '@warehouse/model/gathering-detail.model';
import {GatheringControlList} from '@warehouse/model/gathering-control-list.model';
import {OrderGathering} from '@warehouse/model/order-gathering.model';
import {Subject} from 'rxjs';
import {first} from 'rxjs/operators';

@Component({
  selector: 'ot-waybill-printout',
  templateUrl: './waybill-printout.component.html',
  styleUrls: ['./waybill-printout.component.scss']
})
export class WaybillPrintoutComponent implements OnInit {
  @Input() client: string;
  @Input() clientAddress: string;
  addressChanged: Subject<string> = new Subject<string>();
  clientAddressRow1 = '';
  clientAddressRow2 = '';
  billDate: Date = new Date();
  @Input() shipmentDate: Date;
  @Input() billNo: number;
  taxOffice = 'Şahinbey Vergi Dairesi';
  taxId = 6141016672;
  transactionDesc = 'Depolar Arası Sevk Fişi';
  @Input() orderDetailList: OrderGathering[];

  // printout format parameters:
  @Input() productCountPerPage: number;
  @Input() pageArray: number[] = [];
  @Input() spaceBeforeHeaderArr = [];
  @Input() spaceAfterHeaderArr = [];
  @Input() headerTableColumnWidthArr = [];
  @Input() productTableColumnWidthArr = [];
  @Input() addressFieldLineLength: number;

  constructor() { }

  ngOnInit() {
    this.addressChanged.pipe(first()).subscribe(address => {
      if (this.clientAddress && this.clientAddress.length) {
        const words = this.clientAddress.trim().split(' ');
        let wordIndex = 0;
        do {
          this.clientAddressRow1 += words[wordIndex] + ' ';
          wordIndex++;
        }
        while (wordIndex < words.length && this.clientAddressRow1.length + words[wordIndex].length <= this.addressFieldLineLength);
        if (wordIndex < words.length) {
          do {
            this.clientAddressRow2 += words[wordIndex] + ' ';
            wordIndex++;
          }
          while (wordIndex < words.length && this.clientAddressRow2.length + words[wordIndex].length <= this.addressFieldLineLength);
        }
      }
    });
  }

}

