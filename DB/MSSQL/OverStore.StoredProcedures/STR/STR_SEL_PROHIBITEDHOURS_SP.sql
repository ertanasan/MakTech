-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_PROHIBITEDHOURS_SP
    @ProhibitedHoursId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PROHIBITEDHOURSID,
           P.ACTION,
           P.STORE_CD,
           P.STARTHOUR_NO,
           P.ENDHOUR_NO      
      FROM STR_PROHIBITEDHOURS P (NOLOCK)
     WHERE P.PROHIBITEDHOURSID = @ProhibitedHoursId;

    /*Section="End"*/
END;
