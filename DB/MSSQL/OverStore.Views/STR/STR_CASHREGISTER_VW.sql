﻿CREATE VIEW STR_CASHREGISTER_VW AS
SELECT STORE, MAX(B.BRAND_NM) TERMINAL
  FROM STR_CASHREGISTER CR 
  JOIN STR_CASHREGISTERMODEL M ON CR.CASHREGISTERMODEL = M.CASHREGISTERMODELID 
  JOIN STR_CASHREGISTERBRAND B ON M.BRAND = B.CASHREGISTERBRANDID
 GROUP BY STORE