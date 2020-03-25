﻿CREATE PROCEDURE PRC_LST_NEWPRICEPACKAGES_SP
	@STOREID INT
AS
BEGIN
    
    BEGIN TRANSACTION TRX;
   
    SELECT
           P.PACKAGEDETID,
           P.EVENT,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.CREATECHANNEL,
           P.CREATEBRANCH,
           P.CREATESCREEN,
           P.PACKAGE,
           P.STORE,
           P.DEVICEGROUP,
           P.STATUS 
      FROM PRC_PACKAGEDETAIL P WITH (UPDLOCK, ROWLOCK, READPAST)
     WHERE P.STORE = @STOREID
	   AND P.STATUS = 1;

    UPDATE PRC_PACKAGEDETAIL
       SET STATUS = 5 -- In Progress
     WHERE STORE = @STOREID
	   AND STATUS = 1;
    
	COMMIT TRANSACTION TRX;

END;
