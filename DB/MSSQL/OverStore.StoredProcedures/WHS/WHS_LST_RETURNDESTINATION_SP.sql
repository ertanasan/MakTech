-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_RETURNDESTINATION_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           R.RETURNDESTINATIONID,
           R.DESTINATION_NM
      FROM WHS_RETURNDESTINATION R (NOLOCK)
     ORDER BY R.RETURNDESTINATIONID;

/*Section="End"*/
END;
