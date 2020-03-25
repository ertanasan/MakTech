CREATE PROCEDURE RCL_LST_CARDDIST_SP @StoreRecId INT AS
BEGIN

    SELECT C.CARDDISTID,
           C.EVENT,
           C.ORGANIZATION,
           C.DELETED_FL,
           C.CREATE_DT,
           C.UPDATE_DT,
           C.CREATEUSER,
           C.UPDATEUSER,
           C.CREATECHANNEL,
           C.CREATEBRANCH,
           C.CREATESCREEN,
           C.CARDGROUP_CD,
           C.CARDZET_AMT,
           C.STOREREC,
		   CASE C.CARDGROUP_CD
		   WHEN 1 THEN 'KASA 1 Kredi Kartı Gün Sonu'
		   WHEN 2 THEN 'KASA 2 Kredi Kartı Gün Sonu'
		   WHEN 3 THEN '1.Mobil POS Kredi Kartı Gün Sonu'
		   WHEN 4 THEN '2.Mobil POS Kredi Kartı Gün Sonu'
		   END CARDGROUP_NM
      FROM RCL_CARDDIST C (NOLOCK)
     WHERE DELETED_FL = 'N'
	   AND STOREREC = @StoreRecId
     ORDER BY CARDDISTID;

END;
