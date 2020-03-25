-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_UPD_STOREPACKAGE_SP
    @StorePackageId INT,
    @Store          INT,
    @Package        INT,
    @PriorityNumber INT,
    @IsCurrentFlag  VARCHAR(1),
    @CurrentVersion INT,
    @StartTime      DATETIME,
    @EndTime        DATETIME
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRC_STOREPACKAGE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE = @Store,
           PACKAGE = @Package,
           PRIORITY_NO = @PriorityNumber,
           ISCURRENT_FL = @IsCurrentFlag,
           CURRENTVERSION = @CurrentVersion,
           START_TM = @StartTime,
           END_TM = @EndTime
     WHERE STOREPACKAGEID = @StorePackageId     
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
