﻿// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class GamePlayer extends ModelBase {
    public GamePlayerId = 0;
    public PlayerName: string;
    public Branch?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GamePlayerId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GamePlayerId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
