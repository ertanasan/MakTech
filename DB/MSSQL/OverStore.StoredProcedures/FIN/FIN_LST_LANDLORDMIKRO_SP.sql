﻿CREATE PROCEDURE [dbo].[FIN_LST_LANDLORDMIKRO_SP]
AS
	WITH CARIHESAPLAR AS (
	SELECT 
		   CAST(cari_Guid AS varchar(100))	LANDLORDGUID
		 , cari_kod							CODE_TXT
		 , cari_unvan1						NAME1_TXT
		 , cari_unvan2						NAME2_TXT
		 , CASE cari_doviz_cinsi2 WHEN 255 THEN 'TRY' ELSE 'USD' END CURRENCY_TXT	 
		 , cari_vdaire_adi					TAXOFFICE_TXT
		 , cari_vdaire_no					NATIONALIDORTAXPAYERID
		 , CASE LEN(cari_vdaire_no) WHEN 11 THEN 0 ELSE 1 END LANDLORDTYPE_CD -- 0: Gerçek Kişi,  1: Tüzel Kişi
		 , cari_VergiKimlikNo				TAXID
		 , cari_banka_hesapno1				IBAN1_TXT
		 , cari_muhartikeli					CODE2_TXT
	  FROM MIK_CURRENTACCOUNT20_SYN
	 WHERE cari_kod LIKE '336%'	
	) SELECT 
		   LANDLORDGUID
		 , CODE_TXT
		 , CODE2_TXT
		 , NAME1_TXT
		 , NAME2_TXT
		 , CURRENCY_TXT
		 , LANDLORDTYPE_CD
		 , '' LANDLORD_ADR
		 , '' CONTACT_TXT
		 , CASE LANDLORDTYPE_CD WHEN 0 THEN NATIONALIDORTAXPAYERID ELSE '' END NATIONALID_TXT
		 , CASE TAXID WHEN '' THEN (CASE LANDLORDTYPE_CD WHEN 0 THEN '' ELSE NATIONALIDORTAXPAYERID END) ELSE TAXID END TAXPAYERID_TXT
		 , TAXOFFICE_TXT
		 , IBAN1_TXT
	  FROM CARIHESAPLAR