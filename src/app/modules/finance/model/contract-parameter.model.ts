// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ContractParameter extends ModelBase {
    public ContractParameterId = 0;
    public ParameterName: string;
    public Value: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ContractParameterId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ContractParameterId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
