﻿CREATE PROCEDURE [dbo].[ACC_DEL_LOOMISDATE_SP] @SaleDate DATE AS
BEGIN

  DELETE 
    FROM ACC_LOOMIS 
   WHERE SALE_DT = @SaleDate 

END