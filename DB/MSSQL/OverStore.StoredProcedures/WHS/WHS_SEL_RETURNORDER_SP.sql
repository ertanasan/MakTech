-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_RETURNORDER_SP
    @ReturnOrderId BIGINT
AS
BEGIN
    SELECT
           R.RETURNORDERID,
           R.EVENT,
           R.ORGANIZATION,
           R.DELETED_FL,
           R.CREATE_DT,
           R.UPDATE_DT,
           R.CREATEUSER,
           R.UPDATEUSER,
           R.CREATECHANNEL,
           R.CREATEBRANCH,
           R.CREATESCREEN,
           R.STORE,
           R.STATUS,
           R.PROCESSINSTANCE_LNO
      FROM WHS_RETURNORDER R (NOLOCK)
     WHERE R.RETURNORDERID = @ReturnOrderId;
END;
