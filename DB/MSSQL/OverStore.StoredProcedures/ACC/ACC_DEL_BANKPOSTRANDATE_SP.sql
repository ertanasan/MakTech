﻿CREATE PROCEDURE [dbo].[ACC_DEL_BANKPOSTRANDATE_SP] @BlockedDate DATE AS
BEGIN

  DELETE 
    FROM ACC_BANKPOSTRAN
   WHERE BLOCKED_DT = @BlockedDate

END