-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_MATERIALORDERDETAIL_SP
    @MaterialOrderDetailId BIGINT
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
           M.MATERIALORDERDETAILID,
           M.EVENT,
           M.ORGANIZATION,
           M.DELETED_FL,
           M.CREATE_DT,
           M.UPDATE_DT,
           M.CREATEUSER,
           M.UPDATEUSER,
           M.CREATECHANNEL,
           M.CREATEBRANCH,
           M.CREATESCREEN,
           M.MATERIALORDER,
           M.MATERIAL,
           M.ORDER_AMT,
           M.REVISED_AMT,
           M.SHIPPED_AMT,
           M.INTAKE_AMT,
           M.NOTE_TXT      
      FROM WHS_MATERIALORDERDETAIL M (NOLOCK)
     WHERE M.MATERIALORDERDETAILID = @MaterialOrderDetailId     
       AND (@Organization IS NULL OR M.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
