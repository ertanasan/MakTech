﻿CREATE PROCEDURE WHS_DEL_STOCKTAKING_SP
    @StockTakingId BIGINT
AS
BEGIN
    
    SET NOCOUNT OFF

    DELETE FROM WHS_STOCKTAKING
     WHERE STOCKTAKINGID = @StockTakingId;

    SET NOCOUNT ON;

END;
