// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Payroll extends ModelBase {
    public PayrollId = 0;
    public Event = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public Employee: number;
    public YearCode: number;
    public MonthCode: number;
    public WorkingDay?: number;
    public WorkingHours?: number;
    public PayAmount?: number;
    public AnnualLeave?: number;
    public AnnualLeaveHours?: number;
    public AnnualLeavePay?: number;
    public PaidLeavewithExcuseDayCount?: number;
    public PaidLeavewithExcuseHours?: number;
    public PaidLeavewithExcusePayAmount?: number;
    public LeaveNoPaywithMedicalReportDayCount?: number;
    public LeaveNoPaywithMedicalReportHours?: number;
    public LeaveNoPaywithoutExcuseDayCount?: number;
    public LeaveNoPaywithoutExcuseHours?: number;
    public AbsenceDayCount?: number;
    public AbsenceHours?: number;
    public LegalHolidayHours?: number;
    public LegalHolidayPayAmount?: number;
    public OvertimeHours?: number;
    public OvertimePayAmount?: number;
    public CashIndemnityAmount?: number;
    public FoodAllowanceAmount?: number;
    public FoodAllowanceDayCount?: number;
    public LeavePayAmount?: number;
    public AdvanceAmount?: number;
    public PayCutAmount?: number;
    public InstallmentPayCutAmount?: number;
    public InsuranceCutAmount?: number;
    public AlimonyCutAmount?: number;
    public ExecutionDeduction1Amount?: number;
    public ExecutionDeduction2Amount?: number;
    public ExecutionDeduction3Amount?: number;
    public InsuranceDayCount?: number;
    public AssessmentAmount?: number;
    public InsuranceCutWorkerAmount?: number;
    public InsuranceCutEmployerAmount?: number;
    public UnemploymentPremiumWorkerAmount?: number;
    public UnemploymentPremiumEmployerAmount?: number;
    public StampTaxAmount?: number;
    public PreviousTaxAssessmentAmount?: number;
    public TaxAssessmentAmount?: number;
    public IncomeTaxAmount?: number;
    public IncomeTaxRate?: number;
    public TotalWithholdingAmount?: number;
    public MinimumLivingAllowanceAmount?: number;
    public NetAmount?: number;
    public TotalGrossRevenueAmount?: number;
    public IncentiveShare5510Amount?: number;
    public IncentiveShare6111Amount?: number;
    public IncentiveShare2828Amount?: number;
    public IncentiveShare27103Amount?: number;
    public IncentiveShare14857Amount?: number;
    public IncomeTaxIncentiveShareAmount?: number;
    public UnemploymentIncentiveShareAmount?: number;
    public TaxIncentiveAmount?: number;

    public EmployeeName?: string;
    public WorkingType?: string;
    public StartDate?: Date;
    public QuitDate?: Date;
    public DepartmentName?: string;
    public ExpenseCenter?: string;
    public IncentiveActCode?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PayrollId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.PayrollId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}

export class MikroTransferPayrollListModel {
    public Year: number;
    public Month: number;
}
