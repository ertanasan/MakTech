﻿CREATE VIEW PRD_SEARCHCODE_VW AS
WITH PRODUCTS AS
(SELECT PRODUCTID, CODE_NM, OLDCODE_NM, BARCODE_TXT, UNIT, ROW_NUMBER() OVER (PARTITION BY PRODUCTID ORDER BY B.CREATE_DT DESC) ROWNO
   FROM PRD_PRODUCT P
   JOIN PRD_BARCODE B ON P.PRODUCTID = B.PRODUCT),
PRODUCTLOG AS (
 SELECT PL.PRODUCTID, CODE_NM, OLDCODE_NM, BARCODE_TXT, UNIT, ROW_NUMBER() OVER (PARTITION BY PRODUCTID ORDER BY B.CREATE_DT DESC) ROWNO
   FROM PRD_PRODUCTLOG PL
   JOIN PRD_BARCODE B ON PL.PRODUCTID = B.PRODUCT),
PRODUCTUNION AS (
SELECT CODE_NM SEARCHCODE, PRODUCTID, UNIT, BARCODE_TXT, 1 PRIORITY FROM PRODUCTS WHERE ROWNO = 1
 UNION ALL
SELECT BARCODE_TXT SEARCHCODE, PRODUCTID, UNIT, BARCODE_TXT, 2 FROM PRODUCTS 
 UNION ALL
SELECT OLDCODE_NM SEARCHCODE, PRODUCTID, UNIT, BARCODE_TXT, 3 FROM PRODUCTS WHERE ROWNO = 1
 UNION ALL
SELECT CODE_NM SEARCHCODE, PRODUCTID, UNIT, BARCODE_TXT, 4 FROM PRODUCTLOG WHERE ROWNO = 1
 UNION ALL
SELECT OLDCODE_NM SEARCHCODE, PRODUCTID, UNIT, BARCODE_TXT, 5 FROM PRODUCTLOG WHERE ROWNO = 1)
SELECT *
  FROM (
SELECT *, ROW_NUMBER() OVER (PARTITION BY SEARCHCODE ORDER BY PRIORITY) PRIORROW
  FROM PRODUCTUNION) A
 WHERE PRIORROW = 1