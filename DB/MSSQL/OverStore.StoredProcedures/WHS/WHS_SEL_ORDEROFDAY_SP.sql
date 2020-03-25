﻿CREATE PROCEDURE [dbo].[WHS_SEL_ORDEROFDAY_SP]
	@StoreId INT,
	@Day DATETIME
AS
BEGIN

  SELECT *
    FROM WHS_STOREORDER
   WHERE STORE = @StoreId
     AND CAST(SHIPMENT_DT AS DATE) = CAST(@Day AS DATE)
	 AND [STATUS] != 9
	 AND DELETED_FL = 'N'

END