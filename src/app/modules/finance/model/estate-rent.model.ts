// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import {FolderHandle} from '@otmodel/folder-handle.model';

/*Section="ClassHeader"*/
export class EstateRent extends ModelBase {
    public EstateRentId = 0;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public ContractDraftVersion?: number;
    public ContractFolder?: number;
    public EstateAddress?: string;
    public RentPurpose?: string;
    public ContractStartDate: Date;
    public ContractEndDate: Date;
    public EstateName?: string;
    public Comment?: string;
    public Branch?: number;
    public Deposit?: number;
    public DepositCurrency = 'TRY';
    public DepositDetails?: string;
    public AdditionalDeposit?: number;
    public AdditionalDepositCurrency = 'TRY';
    public AgentFee?: number;
    public AgentFeeCurrency = 'TRY';
    public AgentFeeDetail?: string;
    public KeyMoney?: number;
    public KeyMoneyCurrency = 'TRY';
    public KeyMoneyDetail?: string;
    public NonrefundableCost?: number;
    public NonrefundableCurrency = 'TRY';
    public NonrefundableCostDetail?: string;

    public RentFolderHandle = new FolderHandle();

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.EstateRentId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.EstateRentId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
