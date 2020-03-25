-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_SEL_UPLOADTYPE_SP
    @UploadTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           U.UPLOADTYPEID,
           U.UPLOADTYPE_NM,
           U.COMMENT_DSC      
      FROM SUP_UPLOADTYPE U (NOLOCK)
     WHERE U.UPLOADTYPEID = @UploadTypeId;

    /*Section="End"*/
END;
