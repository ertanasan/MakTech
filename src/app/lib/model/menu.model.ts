export class Menu {
    MenuId: number;
    Parent?: number;
    Caption: string;
    Icon?: string;
    ModuleName: string;
    ScreenName: string;
    ActionName: string;
    Clickable: boolean;
    Children: Menu[];
}
