CREATE PROCEDURE [dbo].[INV_INS_STOCKTRANSACTIONS_SP] AS      
BEGIN      
      
    DELETE ST
      FROM INV_STOCKTRANSACTIONS ST
      LEFT JOIN MIK_TRANSACTION20_SYN T ON ST.MIKROGUID = T.sth_Guid AND T.sth_cins NOT IN (9, 11)
     WHERE ST.TRANSACTION_DT >= '2020-01-01' 
       AND sth_Guid IS NULL

	IF OBJECT_ID('tempdb..#EINVOICEREC') IS NOT NULL DROP TABLE #EINVOICEREC
	SELECT T.sth_Guid
	  INTO #EINVOICEREC
	  FROM MIK_TRANSACTION20_SYN T
	  JOIN MaktechProd.dbo.ACC_INVOICE I on T.sth_evrakno_sira = I.SALE AND I.DELETED_FL = 'N' AND T.sth_evrakno_seri like 'MP%'
	  JOIN MaktechProd.dbo.SLS_SALE S on I.SALE = S.SALEID
	 WHERE T.sth_evraktip = 4
	   AND S.TRANSACTIONTYPE IN (1,2)
      
    INSERT INTO INV_STOCKTRANSACTIONS
    (WAREHOUSE, TRANSACTION_DT, PRODUCT, TRANSACTIONTYPE, QUANTITY_QTY, AMOUNT_AMT, COUNTERWAREHOUSE, INFO_TXT, MIKROGUID)
    SELECT WG.WAREHOUSEID, sth_tarih TRANSACTION_DT, P.PRODUCTID,
           CASE WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 2 THEN 1
                WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 1 THEN 3
                WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 1 THEN 6
                WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 2 THEN 8
           END TRANSACTIONTYPE,
           sth_miktar QUANTITY_QTY, ROUND(sth_tutar*sth_har_doviz_kuru,6) AMOUNT_AMT, WC.WAREHOUSEID COUNTERWAREHOUSE,
           CAST(sth_evraktip as varchar(10))+'-'+sth_evrakno_seri+'-'+CAST(sth_evrakno_sira as varchar(100))+'-'+CAST(sth_satirno as varchar(100))+'-'+sth_belge_no INFO_TXT,
           t.sth_Guid MIKROGUID
      FROM MIK_TRANSACTION20_SYN t
      JOIN INV_WAREHOUSE WG ON t.sth_giris_depo_no = WG.WAREHOUSEID
      JOIN INV_WAREHOUSE WC ON t.sth_cikis_depo_no = WC.WAREHOUSEID
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON t.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM
	  LEFT JOIN #EINVOICEREC R ON t.sth_Guid = R.sth_Guid
      LEFT JOIN INV_STOCKTRANSACTIONS ST ON ST.MIKROGUID = t.sth_Guid
       AND ST.TRANSACTIONTYPE = CASE WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 2 THEN 1
                                     WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 1 THEN 3
                                     WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 1 THEN 6
                                     WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 2 THEN 8 END
     WHERE sth_tarih >= '2019-01-01'
       AND sth_tip = 2      
       AND ST.MIKROGUID IS NULL
	   AND R.sth_Guid IS NULL
      
    UPDATE ST      
       SET TRANSACTION_DT = sth_tarih      
         , QUANTITY_QTY = sth_miktar    
         , AMOUNT_AMT = ROUND(sth_tutar*sth_har_doviz_kuru,6)  
      FROM MIK_TRANSACTION20_SYN t      
      JOIN INV_WAREHOUSE WG ON t.sth_giris_depo_no = WG.WAREHOUSEID      
      JOIN INV_WAREHOUSE WC ON t.sth_cikis_depo_no = WC.WAREHOUSEID      
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON t.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM      
      JOIN INV_STOCKTRANSACTIONS ST ON ST.MIKROGUID = t.sth_Guid       
       AND ST.TRANSACTIONTYPE = CASE WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 2 THEN 1      
                                     WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 1 THEN 3      
                                     WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 1 THEN 6      
                                     WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 2 THEN 8 END      
     WHERE sth_tarih >= '2019-01-01'      
       AND sth_tip = 2           
       AND (TRANSACTION_DT != sth_tarih OR QUANTITY_QTY != sth_miktar OR AMOUNT_AMT != ROUND(sth_tutar*sth_har_doviz_kuru,6))      
      
      
    INSERT INTO INV_STOCKTRANSACTIONS      
    (WAREHOUSE, TRANSACTION_DT, PRODUCT, TRANSACTIONTYPE, QUANTITY_QTY, AMOUNT_AMT, COUNTERWAREHOUSE, INFO_TXT, MIKROGUID)    
    SELECT WC.WAREHOUSEID, sth_tarih TRANSACTION_DT, P.PRODUCTID,       
           CASE WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 2 THEN 2      
             WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 1 THEN 4      
             WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 1 THEN 5      
             WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 2 THEN 7      
           END TRANSACTIONTYPE,      
           -1*sth_miktar QUANTITY_QTY, ROUND(sth_tutar*sth_har_doviz_kuru,6) AMOUNT_AMT, WG.WAREHOUSEID COUNTERWAREHOUSE,       
           cast(sth_evraktip as varchar(10))+'-'+sth_evrakno_seri+'-'+cast(sth_evrakno_sira as varchar(100))+'-'+cast(sth_satirno as varchar(100))+'-'+sth_belge_no INFO_TXT,      
           t.sth_Guid MIKROGUID      
      FROM MIK_TRANSACTION20_SYN t      
      JOIN INV_WAREHOUSE WG ON t.sth_giris_depo_no = WG.WAREHOUSEID      
      JOIN INV_WAREHOUSE WC ON t.sth_cikis_depo_no = WC.WAREHOUSEID      
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON t.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM      
	  LEFT JOIN #EINVOICEREC R ON t.sth_Guid = R.sth_Guid
      LEFT JOIN INV_STOCKTRANSACTIONS ST ON ST.MIKROGUID = t.sth_Guid       
       AND ST.TRANSACTIONTYPE = CASE WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 2 THEN 2      
                                     WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 1 THEN 4              
                                     WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 1 THEN 5      
                                     WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 2 THEN 7 END      
     WHERE sth_tarih >= '2019-01-01'      
       AND sth_tip = 2      
       AND ST.MIKROGUID IS NULL      
	   AND R.sth_Guid IS NULL
      
    UPDATE ST      
       SET TRANSACTION_DT = sth_tarih      
         , QUANTITY_QTY = -1*sth_miktar      
         , AMOUNT_AMT = ROUND(sth_tutar*sth_har_doviz_kuru,6)    
      FROM MIK_TRANSACTION20_SYN t      
      JOIN INV_WAREHOUSE WG ON t.sth_giris_depo_no = WG.WAREHOUSEID      
      JOIN INV_WAREHOUSE WC ON t.sth_cikis_depo_no = WC.WAREHOUSEID      
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON t.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM      
      JOIN INV_STOCKTRANSACTIONS ST ON ST.MIKROGUID = t.sth_Guid       
       AND ST.TRANSACTIONTYPE = CASE WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 2 THEN 2      
                                     WHEN WG.WAREHOUSETYPE = 1 AND WC.WAREHOUSETYPE = 1 THEN 4      
                                     WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 1 THEN 5      
                                     WHEN WG.WAREHOUSETYPE = 2 AND WC.WAREHOUSETYPE = 2 THEN 7 END      
     WHERE sth_tarih >= '2019-01-01'      
       AND sth_tip = 2      
       AND (TRANSACTION_DT != sth_tarih OR QUANTITY_QTY != -1*sth_miktar OR AMOUNT_AMT != ROUND(sth_tutar*sth_har_doviz_kuru,6))      
      
    INSERT INTO INV_STOCKTRANSACTIONS      
    (WAREHOUSE, TRANSACTION_DT, PRODUCT, TRANSACTIONTYPE, QUANTITY_QTY, AMOUNT_AMT, COUNTERWAREHOUSE, INFO_TXT, MIKROGUID)    
    SELECT WG.WAREHOUSEID, sth_tarih TRANSACTION_DT, P.PRODUCTID,       
           CASE WHEN WG.WAREHOUSETYPE = 1 THEN 11      
                WHEN WG.WAREHOUSETYPE = 2 THEN 9      
           END TRANSACTIONTYPE,      
           sth_miktar QUANTITY_QTY, ROUND(sth_tutar*sth_har_doviz_kuru,6) AMOUNT_AMT, -1 COUNTERWAREHOUSE,       
           cast(sth_evraktip as varchar(10))+'-'+sth_evrakno_seri+'-'+cast(sth_evrakno_sira as varchar(100))+'-'+cast(sth_satirno as varchar(100))+'-'+sth_belge_no INFO_TXT,      
           t.sth_Guid MIKROGUID      
      FROM MIK_TRANSACTION20_SYN t      
      JOIN INV_WAREHOUSE WG ON t.sth_giris_depo_no = WG.WAREHOUSEID      
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON t.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM      
	  LEFT JOIN #EINVOICEREC R ON t.sth_Guid = R.sth_Guid
      LEFT JOIN INV_STOCKTRANSACTIONS ST ON ST.MIKROGUID = t.sth_Guid       
       AND ST.TRANSACTIONTYPE = CASE WHEN WG.WAREHOUSETYPE = 1 THEN 11 WHEN WG.WAREHOUSETYPE = 2 THEN 9 END        
     WHERE sth_pos_satis = 0      
       AND sth_tarih >= '2019-01-01'      
       AND sth_tip = 0      
       AND sth_cins NOT IN (9, 11)
       AND ST.MIKROGUID IS NULL      
	   AND R.sth_Guid IS NULL
      
    UPDATE ST      
       SET TRANSACTION_DT = sth_tarih      
         , QUANTITY_QTY = sth_miktar      
         , AMOUNT_AMT = ROUND(sth_tutar*sth_har_doviz_kuru,6)    
      FROM MIK_TRANSACTION20_SYN t      
      JOIN INV_WAREHOUSE WG ON t.sth_giris_depo_no = WG.WAREHOUSEID      
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON t.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM      
      JOIN INV_STOCKTRANSACTIONS ST ON ST.MIKROGUID = t.sth_Guid       
       AND ST.TRANSACTIONTYPE = CASE WHEN WG.WAREHOUSETYPE = 1 THEN 11 WHEN WG.WAREHOUSETYPE = 2 THEN 9 END        
     WHERE sth_pos_satis = 0      
       AND sth_tarih >= '2019-01-01'      
       AND sth_tip = 0      
       AND sth_cins NOT IN (9, 11)
       AND (TRANSACTION_DT != sth_tarih OR QUANTITY_QTY != sth_miktar OR AMOUNT_AMT != ROUND(sth_tutar*sth_har_doviz_kuru,6))      
      
    INSERT INTO INV_STOCKTRANSACTIONS      
    (WAREHOUSE, TRANSACTION_DT, PRODUCT, TRANSACTIONTYPE, QUANTITY_QTY, AMOUNT_AMT, COUNTERWAREHOUSE, INFO_TXT, MIKROGUID)    
    SELECT WC.WAREHOUSEID, sth_tarih TRANSACTION_DT, P.PRODUCTID,       
           CASE WHEN WC.WAREHOUSETYPE = 1 THEN 12      
                WHEN WC.WAREHOUSETYPE = 2 THEN 10      
           END TRANSACTIONTYPE,      
           -1* sth_miktar QUANTITY_QTY, ROUND(sth_tutar*sth_har_doviz_kuru,6) AMOUNT_AMT, -1 COUNTERWAREHOUSE,       
           cast(sth_evraktip as varchar(10))+'-'+sth_evrakno_seri+'-'+cast(sth_evrakno_sira as varchar(100))+'-'+cast(sth_satirno as varchar(100))+'-'+sth_belge_no INFO_TXT,      
           t.sth_Guid MIKROGUID      
      FROM MIK_TRANSACTION20_SYN t      
      JOIN INV_WAREHOUSE WC ON t.sth_cikis_depo_no = WC.WAREHOUSEID      
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON t.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM      
	  LEFT JOIN #EINVOICEREC R ON t.sth_Guid = R.sth_Guid
      LEFT JOIN INV_STOCKTRANSACTIONS ST ON ST.MIKROGUID = t.sth_Guid       
       AND ST.TRANSACTIONTYPE = CASE WHEN WC.WAREHOUSETYPE = 1 THEN 12 WHEN WC.WAREHOUSETYPE = 2 THEN 10 END        
     WHERE sth_pos_satis = 0      
       AND sth_tarih >= '2019-01-01'      
       AND sth_tip = 1      
       AND sth_cins NOT IN (9, 11)
       AND ST.MIKROGUID IS NULL      
	   AND R.sth_Guid IS NULL
      
    UPDATE ST      
       SET TRANSACTION_DT = sth_tarih      
         , QUANTITY_QTY = -1*sth_miktar      
         , AMOUNT_AMT = ROUND(sth_tutar*sth_har_doviz_kuru,6)    
      FROM MIK_TRANSACTION20_SYN t      
      JOIN INV_WAREHOUSE WC ON t.sth_cikis_depo_no = WC.WAREHOUSEID      
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON t.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM      
      JOIN INV_STOCKTRANSACTIONS ST ON ST.MIKROGUID = t.sth_Guid       
       AND ST.TRANSACTIONTYPE = CASE WHEN WC.WAREHOUSETYPE = 1 THEN 12 WHEN WC.WAREHOUSETYPE = 2 THEN 10 END        
     WHERE sth_pos_satis = 0      
       AND sth_tarih >= '2019-01-01'      
       AND sth_tip = 1      
       AND sth_cins NOT IN (9, 11)
       AND (TRANSACTION_DT != sth_tarih OR QUANTITY_QTY != -1*sth_miktar OR AMOUNT_AMT != ROUND(sth_tutar*sth_har_doviz_kuru,6))      
      
    UPDATE ST    
       SET ST.WAREHOUSE = T.sth_giris_depo_no    
         , ST.PRODUCT = P.PRODUCTID    
      FROM INV_STOCKTRANSACTIONS ST    
      JOIN MIK_TRANSACTION20_SYN T ON ST.MIKROGUID = t.sth_Guid    
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON T.sth_stok_kod = P.CODE_NM collate Turkish_CI_AS     
     WHERE ST.QUANTITY_QTY > 0     
       AND (ST.WAREHOUSE != T.sth_giris_depo_no or ST.PRODUCT != P.PRODUCTID)    
      
    UPDATE ST    
       SET ST.WAREHOUSE = T.sth_cikis_depo_no  
         , ST.PRODUCT = P.PRODUCTID  
      FROM INV_STOCKTRANSACTIONS ST    
      JOIN MIK_TRANSACTION20_SYN T ON ST.MIKROGUID = t.sth_Guid    
      JOIN MaktechProd.dbo.PRD_PRODUCT P ON T.sth_stok_kod = P.CODE_NM collate Turkish_CI_AS     
     WHERE ST.QUANTITY_QTY < 0     
       AND (ST.WAREHOUSE != T.sth_cikis_depo_no OR ST.PRODUCT != P.PRODUCTID)    

	/* sonda yapmak önce insert olduğundan karışıklığa sebep olabiliyor. o yüzden hiç insert etmemek lazım. 
	-- e-arsivlerden iadesi kesilmeyen hareketleri stok hareketi olarak alma
	DELETE FROM INV_STOCKTRANSACTIONS 
	 WHERE MIKROGUID IN (
	SELECT T.sth_Guid
	  FROM MIK_TRANSACTION20_SYN T
	  JOIN MaktechProd.dbo.ACC_INVOICE I on T.sth_evrakno_sira = I.SALE AND I.DELETED_FL = 'N' AND T.sth_evrakno_seri like 'MP%'
	  JOIN MaktechProd.dbo.SLS_SALE S on I.SALE = S.SALEID
	 WHERE T.sth_evraktip = 4
	   AND S.TRANSACTIONTYPE IN (1,2))
	 */
END