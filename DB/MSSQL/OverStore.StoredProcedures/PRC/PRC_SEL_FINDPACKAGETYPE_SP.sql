﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_SEL_FINDPACKAGETYPE_SP
    @PackageTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           P.PACKAGETYPEID,
           P.PACKAGETYPE_NM,
           P.COMMENT_DSC      
      FROM PRC_PACKAGETYPE P (NOLOCK)
     WHERE P.PACKAGETYPE_NM = @PackageTypeName;

/*Section="End"*/
END;
