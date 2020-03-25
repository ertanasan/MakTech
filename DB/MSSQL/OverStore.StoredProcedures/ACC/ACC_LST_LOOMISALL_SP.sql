﻿CREATE PROCEDURE ACC_LST_LOOMISALL_SP @StartDate DATE = NULL, @EndDate DATE = NULL AS
BEGIN

    SELECT *
      FROM ACC_LOOMIS L (NOLOCK)
     WHERE LOOMIS_DT BETWEEN ISNULL(@StartDate, CONVERT(DATE, '20180101', 112)) AND ISNULL(@EndDate, CONVERT(DATE, '20491231', 112))
	   AND L.DELETED_FL = 'N';

END;