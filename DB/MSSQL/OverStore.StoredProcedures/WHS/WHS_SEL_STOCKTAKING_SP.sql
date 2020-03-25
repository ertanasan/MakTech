-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_STOCKTAKING_SP
    @StockTakingId BIGINT
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
    -- Select
    SELECT
           S.STOCKTAKINGID,
           S.EVENT,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.CREATECHANNEL,
           S.CREATEBRANCH,
           S.CREATESCREEN,
           S.STORE,
           S.COUNTING_DT,
           S.PRODUCT,
           S.COUNTINGVALUE_AMT,
           S.ZONE,
           S.STOCKTAKINGSCHEDULE
      FROM WHS_STOCKTAKING S (NOLOCK)
     WHERE S.STOCKTAKINGID = @StockTakingId
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
