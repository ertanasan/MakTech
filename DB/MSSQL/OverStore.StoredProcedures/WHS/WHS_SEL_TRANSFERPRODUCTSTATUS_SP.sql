-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_TRANSFERPRODUCTSTATUS_SP
    @TransferProductStatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           T.TRANSFERPRODUCTSTATUSID,
           T.PRODUCTSTATUS_NM      
      FROM WHS_TRANSFERPRODUCTSTATUS T (NOLOCK)
     WHERE T.TRANSFERPRODUCTSTATUSID = @TransferProductStatusId;

    /*Section="End"*/
END;
