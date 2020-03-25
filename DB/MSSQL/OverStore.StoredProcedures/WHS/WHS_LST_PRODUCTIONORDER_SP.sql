-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_PRODUCTIONORDER_SP
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
           P.PRODUCTIONORDERID,
           P.EVENT,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.CREATECHANNEL,
           P.CREATEBRANCH,
           P.CREATESCREEN,
           P.PRODUCTION,
           P.QUANTITY_QTY,
           P.STATUS_CD,
           P.PROCESSINSTANCE_LNO,
           P.COMPLETED_QTY
      FROM WHS_PRODUCTIONORDER P (NOLOCK)
     WHERE (@Organization IS NULL OR P.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY PRODUCTION;

/*Section="End"*/
END;
