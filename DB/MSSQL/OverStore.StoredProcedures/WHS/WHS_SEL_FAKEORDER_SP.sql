-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_FAKEORDER_SP
    @FakeOrderId BIGINT
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
           F.FAKEORDERID,
           F.EVENT,
           F.ORGANIZATION,
           F.DELETED_FL,
           F.CREATE_DT,
           F.UPDATE_DT,
           F.CREATEUSER,
           F.UPDATEUSER,
           F.CREATECHANNEL,
           F.CREATEBRANCH,
           F.CREATESCREEN,
           F.ORDER_DT,
           F.STORE,
           F.PRODUCT,
           F.SENT_AMT      
      FROM WHS_FAKEORDER F (NOLOCK)
     WHERE F.FAKEORDERID = @FakeOrderId     
       AND (@Organization IS NULL OR F.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
