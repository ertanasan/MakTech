﻿CREATE PROCEDURE WHS_LST_ZONE_SP @Store INT = 1 AS
BEGIN

    SELECT Z.ZONEID,
           Z.LOCATION_TXT,
           Z.ZONE_NM
      FROM WHS_ZONE Z (NOLOCK)
	 WHERE ((@Store = 1 AND LOCATION_TXT = 'STORE') OR (@Store = 2 AND LOCATION_TXT = 'WAREHOUSE_G') OR (@Store = 3 AND LOCATION_TXT = 'WAREHOUSE_D'))
     ORDER BY ZONE_NM;

END;
