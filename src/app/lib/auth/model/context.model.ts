import { OTContextField } from './context-field.model';

export class OTContext {
    public UserCulture = 'tr';
    public UserCurrency = 'TRY';
    public UserCurrencySymbol = '₺';
    public UserLanguage = 'tr';
    public Tier = 'Client';
    public Environment = 'Debug';
    public Channel = new OTContextField(0, 'Unknown');
    public User = new OTContextField(0, 'Unknown');
    public Language = new OTContextField(0, 'Unknown');
    public Organization = new OTContextField(0, 'Unknown');
    public Branch = new OTContextField(0, 'Unknown');
    public TenantId = 0;
    public TenantKey = '';

    constructor() {}
}
