CREATE procedure [dbo].[MIK_INS_CREATEWORKDATATABLES_SP] @StoreId int, @date date as      
begin      
      
  declare @datestring char(8)      
  set @datestring = convert(char(8), @date, 112);      
      
  declare @store char(3)      
  set @store = REPLACE(STR(@StoreId, 3), SPACE(1), '0');      
      
  declare @query nvarchar(max)      
      
  declare @stable varchar(200)      
  set @stable = '[MikroDB_V16_MAKBUL'+substring(@datestring,3,2)+'_WORKDATA].[dbo].[S_'+@datestring+'_'+@store+']';      
  IF OBJECT_ID(@stable, 'U') IS NOT NULL       
  begin      
    set @query = 'drop table '+@stable      
 exec (@query);      
  end;      
      
  set @query = 'select * into '+@stable+' from MIK_WORKDATATABLES'      
  exec(@query);      
      
  declare @otable varchar(200)      
  set @otable = '[MikroDB_V16_MAKBUL'+substring(@datestring,3,2)+'_WORKDATA].[dbo].[O_'+@datestring+'_'+@store+']';      
  IF OBJECT_ID(@otable, 'U') IS NOT NULL       
  begin      
    set @query = 'drop table '+@otable      
 exec (@query);      
  end;      
      
  set @query = 'select * into '+@otable+' from MIK_WORKDATATABLEO'      
  exec(@query);      
      
  set @query = 'create UNIQUE NONCLUSTERED INDEX [NDX_O_'+@datestring+'_'+@store+'_02] on '+@otable+' ([po_KasaKodu] ASC, [po_BelgeNo] ASC)';    
  exec(@query);    
    
  set @query = 'alter table '+@stable+' add constraint [NDX_S_'+@datestring+'_'+@store+'_00] primary key clustered ([sth_Guid] ASC)';    
  exec(@query);    
    
  set @query = 'alter table '+@otable+' add constraint [NDX_O_'+@datestring+'_'+@store+'_00] primary key clustered ([po_Guid] ASC)';    
  exec(@query);    
    
end; 