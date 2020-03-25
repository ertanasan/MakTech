export interface IDialogAction {
    name: string;
    isAcceptable: boolean;
    isIdentityHidden?: boolean;
    isIdentityEditable?: boolean;
    title?: string;
    successMessageTemplate?: string;
    failMessageTemplate?: string;
    replacements?: {[key: string]: string};
    masterId?: number;
    controlsDisabled?: boolean;
    hasChildren?: boolean;
    children?: string;
    submitCallback?: () => void;
}
