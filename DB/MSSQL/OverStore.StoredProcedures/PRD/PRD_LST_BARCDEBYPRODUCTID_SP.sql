﻿CREATE PROCEDURE [dbo].[PRD_LST_BARCDEBYPRODUCTID_SP] @Product INT AS

SELECT * 
  FROM PRD_BARCODE B
 WHERE PRODUCT = @Product
