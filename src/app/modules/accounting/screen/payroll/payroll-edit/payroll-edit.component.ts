// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Payroll } from '@accounting/model/payroll.model';
import { PayrollService } from '@accounting/service/payroll.service';
import { Employee } from '@store/model/employee.model';
import { EmployeeService } from '@store/service/employee.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-payroll-edit',
    templateUrl: './payroll-edit.component.html',
    styleUrls: ['./payroll-edit.component.css', ]
})
export class PayrollEditComponent extends CRUDDialogScreenBase<Payroll> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Payroll>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: PayrollService,
        public employeeService: EmployeeService,
    ) {
        super(messageService, translateService, dataService, 'Payroll');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            PayrollId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            Employee: new FormControl(),
            YearCode: new FormControl(),
            MonthCode: new FormControl(),
            WorkingDay: new FormControl(),
            WorkingHours: new FormControl(),
            PayAmount: new FormControl(),
            AnnualLeave: new FormControl(),
            AnnualLeaveHours: new FormControl(),
            AnnualLeavePay: new FormControl(),
            PaidLeavewithExcuseDayCount: new FormControl(),
            PaidLeavewithExcuseHours: new FormControl(),
            PaidLeavewithExcusePayAmount: new FormControl(),
            LeaveNoPaywithMedicalReportDayCount: new FormControl(),
            LeaveNoPaywithMedicalReportHours: new FormControl(),
            LeaveNoPaywithoutExcuseDayCount: new FormControl(),
            LeaveNoPaywithoutExcuseHours: new FormControl(),
            AbsenceDayCount: new FormControl(),
            AbsenceHours: new FormControl(),
            LegalHolidayHours: new FormControl(),
            LegalHolidayPayAmount: new FormControl(),
            OvertimeHours: new FormControl(),
            OvertimePayAmount: new FormControl(),
            CashIndemnityAmount: new FormControl(),
            FoodAllowanceAmount: new FormControl(),
            FoodAllowanceDayCount: new FormControl(),
            LeavePayAmount: new FormControl(),
            AdvanceAmount: new FormControl(),
            PayCutAmount: new FormControl(),
            InstallmentPayCutAmount: new FormControl(),
            InsuranceCutAmount: new FormControl(),
            AlimonyCutAmount: new FormControl(),
            ExecutionDeduction1Amount: new FormControl(),
            ExecutionDeduction2Amount: new FormControl(),
            ExecutionDeduction3Amount: new FormControl(),
            InsuranceDayCount: new FormControl(),
            AssessmentAmount: new FormControl(),
            InsuranceCutWorkerAmount: new FormControl(),
            InsuranceCutEmployerAmount: new FormControl(),
            UnemploymentPremiumWorkerAmount: new FormControl(),
            UnemploymentPremiumEmployerAmount: new FormControl(),
            StampTaxAmount: new FormControl(),
            TaxIncentiveAmount: new FormControl(),
            PreviousTaxAssessmentAmount: new FormControl(),
            TaxAssessmentAmount: new FormControl(),
            IncomeTaxAmount: new FormControl(),
            IncomeTaxRate: new FormControl(),
            TotalWithholdingAmount: new FormControl(),
            MinimumLivingAllowanceAmount: new FormControl(),
            NetAmount: new FormControl(),
            TotalGrossRevenueAmount: new FormControl(),
            IncentiveShare5510Amount: new FormControl(),
            IncentiveShare6111Amount: new FormControl(),
            IncentiveShare2828Amount: new FormControl(),
            IncentiveShare27103Amount: new FormControl(),
            IncentiveShare14857Amount: new FormControl(),
            IncomeTaxIncentiveShareAmount: new FormControl(),
            UnemploymentIncentiveShareAmount: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
