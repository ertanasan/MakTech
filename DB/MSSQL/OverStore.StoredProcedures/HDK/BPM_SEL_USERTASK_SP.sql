﻿CREATE PROCEDURE BPM_SEL_USERTASK_SP @ProcessInstanceId BIGINT AS
BEGIN

    DECLARE @CurrentUser INT = dbo.SYS_GETCURRENTUSER_FN();

	SELECT ACTIONID, SCREEN_REF
	  FROM BPM_ACTION_VW 
	 WHERE PROCESSINSTANCE = @ProcessInstanceId
	   AND USERID = @CurrentUser 

END