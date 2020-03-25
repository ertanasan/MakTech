// AUTH types of users for managing view based authentication
export enum UserAuthType {
    Admin = 'Admin',
    Head = 'HeadQuarter',
    Region = 'Region',
    Branch = 'Branch',
    Other = 'Other'
}

// px value of column width in Kendo Grid
export enum KendoGridCommandColumnWidth {
    OneButtonWithoutNew = 35,
    OneButton = 70,
    TwoButton = 70,
    ThreeButton = 105,
    FourButton = 140,
}

// excel file column type
export const ExcelFileColumnType =  [
    {value: 1, text: 'Text'},
    {value: 2, text: 'Decimal'},
    {value: 3, text: 'Date'},
];

// for StockTaking screen
export enum ZoneTypes {
    Store = 1,
    WarehouseGeneral = 2,
    WarehouseDrill = 3
}

// BPM Process Status
export const BpmProcessStatus = [
    {value: 0,  text: 'Initial',                description: 'Aktivite henüz başlatılmamış(henüz bir activity instance oluşmadı)'},
    {value: 1,  text: 'Pending',                description: 'Dış servisten cevap geldi ama process çalıştırmadı veya başlangıç aktivitesi başlatıldı ama çalıştırılmadı'},
    {value: 2,  text: 'Active',                 description: 'Process çalıştırıyor'},
    {value: 3,  text: 'Idle',                   description: 'Dış servisten cevap bekleniyor (activity tablosunda var) veya aktivitenin çalışması için önşartlar oluşmamış (joinactivity)'},
    {value: 4,  text: 'Completed',              description: 'Tamamlandı (activity tablosunda var)'},
    {value: 5,  text: 'Canceled',               description: 'İptal edildi (activity tablosunda var)'},
    {value: 6,  text: 'Failed',                 description: 'Aktivite çalıştırılırken hata aldı'},
    {value: 7,  text: 'Notified',               description: 'Aktivite scheduling servisi tarafından, vakti geldiğinde, notifiede çekildi'},
    {value: 8,  text: 'ReRun',                  description: 'Herhangi bir sebeple hata almış bir aktivite bu statüye çekildiğinde tekrar çalıştırılır.'},
    {value: 9,  text: 'Suspended',              description: 'Durduruldu'},
    {value: 10, text: 'CancelRequested',        description: 'İptal talebi geldi, engine tarafından iptal edilecek.'},
    {value: 11, text: 'WorkSynchronously',      description: 'Senkron çalıştıralacak'},
    {value: 12, text: 'ContinueSyncronously',   description: 'Senkron devam ettirilecek'},
    {value: 13, text: 'EventInitial',           description: 'Event aktivitesi için başlatılmamış.'},
    {value: 14, text: 'EventActive',            description: 'Event aktivitesi için aktif'},
    {value: 15, text: 'EventFailed',            description: 'Event aktivitesi için hata almış'}
];

// BPA Action Status
export const BpaActionStatus = [
    {value: 0, text: 'None'},
    {value: 1, text: 'Waiting'},
    {value: 2, text: 'Completed'},
    {value: 3, text: 'Timedout'},
    {value: 4, text: 'Cancelled'},
    {value: 5, text: 'WaitingOnQueue'},
    {value: 6, text: 'Delegated'}
];

export const PersonOrLegalIdentity = [
    {value: 0, text: 'Natural Person'},
    {value: 1, text: 'Legal Identity'}
];

export const Currencies = [
    {value: 1, text: 'TRY', fasIcon: 'fas fa-lira-sign'},
    {value: 2, text: 'USD', fasIcon: 'fas fa-dollar-sign'},
    {value: 3, text: 'EUR', fasIcon: 'fas fa-euro-sign'}
];
