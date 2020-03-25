import { Subject } from 'rxjs';

import { ModelBase } from '@otmodel/model-base';

export interface IDialogContainer {
    title: string;
    isAcceptable: boolean;
    actionName: string;
    dialogVisible: boolean;
    isIdentityHidden: boolean;
    isIdentityEditable: boolean;
    currentItem: any;
    masterId?: number;
    masterObject?: any;
    leftRelationId?: number;
    leftRelationObject?: any;
    rightRelationId?: number;
    rightRelationObject?: any;
    isReadOnly?: boolean;
    childActions: string;
    onShow: Subject<ModelBase>;
    onHide: Subject<any>;
    useExternalLogic: boolean;
    onDialogAction: Subject<ModelBase>;
    show(dataItem?: ModelBase);
    showProgress();
    hideProgress();
    hide();
}
