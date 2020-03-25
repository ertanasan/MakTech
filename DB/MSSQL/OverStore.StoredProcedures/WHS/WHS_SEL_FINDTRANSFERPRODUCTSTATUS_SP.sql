-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_FINDTRANSFERPRODUCTSTATUS_SP
    @ProductStatusName INT
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           T.TRANSFERPRODUCTSTATUSID,
           T.PRODUCTSTATUS_NM      
      FROM WHS_TRANSFERPRODUCTSTATUS T (NOLOCK)
     WHERE T.PRODUCTSTATUS_NM = @ProductStatusName;

/*Section="End"*/
END;
