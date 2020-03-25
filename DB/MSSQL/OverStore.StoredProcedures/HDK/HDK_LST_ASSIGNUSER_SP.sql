﻿CREATE PROCEDURE HDK_LST_ASSIGNUSER_SP
AS
BEGIN
    SELECT A.ASSIGNUSERID,
           A.GROUP_NM,
           A.RESPONSIBLEUSER,
           A.ADMIN_FL,
           U.USER_NM,
           U.USERFULL_NM
      FROM HDK_ASSIGNUSER A (NOLOCK)
      JOIN SEC_USER U (NOLOCK) ON A.RESPONSIBLEUSER = U.USERID
END;
