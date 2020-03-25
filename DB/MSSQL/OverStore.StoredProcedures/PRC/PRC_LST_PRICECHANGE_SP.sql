-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_LST_PRICECHANGE_SP
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PRICECHANGEID,
           P.ORGANIZATION,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.STORE,
           P.PRODUCTCODE_NM,
           P.PRODUCTNAME_NM,
           P.OPERATION_TXT,
           P.OLDPRICE_AMT,
           P.NEWPRICE_AMT,
           P.STATUS_CD
      FROM PRC_PRICECHANGE P (NOLOCK)
     WHERE (@Organization IS NULL OR P.ORGANIZATION = @Organization)
       AND P.STATUS_CD = 0;

/*Section="End"*/
END;
