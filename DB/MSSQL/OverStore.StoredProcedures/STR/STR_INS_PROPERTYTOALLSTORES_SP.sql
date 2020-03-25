﻿CREATE PROCEDURE [dbo].[STR_INS_PROPERTYTOALLSTORES_SP]
    @PropertyType   INT,
	@PropertyValue	VARCHAR(1000)
AS
BEGIN
	/*Section="Insert SP For Each Store"*/
	INSERT INTO STR_PROPERTY 
	(
        STORE,
        PROPERTYTYPE,
        VALUE_TXT
    )
		SELECT ST.STOREID, @PropertyType, @PropertyValue
		  FROM STR_STORE ST
		  LEFT JOIN (SELECT STORE, MAX(VALUE_TXT) VALUE_TXT FROM STR_PROPERTY WHERE PROPERTYTYPE = @PropertyType GROUP BY STORE) SP ON ST.STOREID = SP.STORE
		WHERE SP.STORE IS NULL AND ST.ACTIVE_FL = 'Y' AND ST.DELETED_FL = 'N'

	SELECT @@ROWCOUNT;
	/*Section="End"*/
END;