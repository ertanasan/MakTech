CREATE PROCEDURE [dbo].[MIK_DEL_PAYROLL_SP] @evraksirano INT AS
BEGIN

  DELETE T
    FROM MIK_CURRENTTRANSACTION19_SYN T
   WHERE T.cha_evrakno_seri = 'MBDR' AND T.cha_evrakno_sira = @evraksirano

  DELETE A
    FROM MIK_ACCOUNTING19_SYN A
   WHERE A.fis_tic_evrak_seri = 'MBDR' AND A.fis_tic_evrak_sira = @evraksirano

  DELETE AD
    FROM MIK_ACCOUNTINGDETAIL19_SYN AD
   WHERE AD.mfd_evrak_seri = 'MBDR' AND AD.mfd_evrak_sira = @evraksirano

END