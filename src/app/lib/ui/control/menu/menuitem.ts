export interface MenuItem {
    Caption?: string;
    Icon?: string;
    Command?: (event?: any) => void;
    Url?: string;
    RouterLink?: any;
    QueryParams?: {
        [k: string]: any;
    };
    Items?: MenuItem[];
    Expanded?: boolean;
    Disabled?: boolean;
    Visible?: boolean;
    Target?: string;
    RouterLinkActiveOptions?: any;
    Separator?: boolean;
    Badge?: string;
    BadgeStyleClass?: string;
    Style?: any;
    StyleClass?: string;
    Title?: string;
    Id?: string;
}
