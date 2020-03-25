// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Employee extends ModelBase {
    public EmployeeId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public EmployeeName: string;
    public DepartmentCode?: number;
    public DepartmentName: string;
    public IncentiveActCode?: number;
    public StartDate?: Date;
    public QuitDate?: Date;
    public WorkingType?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.EmployeeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.EmployeeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
