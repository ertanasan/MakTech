import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { ProductReturnHistory } from '@warehouse/model/product-return.model';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { UserService } from '@frame/security/service/user.service';
import { BpaActionStatus, BpmProcessStatus } from 'app/util/shared-enums.component';

@Component({
  selector: 'ot-product-return-history',
  templateUrl: './product-return-history.component.html',
  styleUrls: ['./product-return-history.component.scss']
})
export class ProductReturnHistoryComponent implements OnInit {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  @Input() historyData: ProductReturnHistory[] = [];
  @Input() processStatus = '';
  @Input() title = '';

  actiontypes = BpaActionStatus;

  constructor(
    public userService: UserService,
  ) { }

  ngOnInit() {
  }

}
