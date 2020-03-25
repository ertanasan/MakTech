-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_RETURNDESTINATION_SP
    @ReturnDestinationId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           R.RETURNDESTINATIONID,
           R.DESTINATION_NM      
      FROM WHS_RETURNDESTINATION R (NOLOCK)
     WHERE R.RETURNDESTINATIONID = @ReturnDestinationId;

    /*Section="End"*/
END;
