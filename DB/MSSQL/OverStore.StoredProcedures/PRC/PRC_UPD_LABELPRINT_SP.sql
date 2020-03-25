﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_UPD_LABELPRINT_SP
    @LabelPrintId BIGINT,
    @Event        INT,
    @Organization INT,
    @Product      INT,
    @CurrentPrice INT,
    @LabelSize    VARCHAR(10)
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRC_LABELPRINT
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           PRODUCT = @Product,
           CURRENTPRICE = @CurrentPrice,
           LABELSIZE_TXT = @LabelSize
     WHERE LABELPRINTID = @LabelPrintId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
