-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_INS_STOREPACKAGE_SP
    @StorePackageId INT OUT,
    @Store          INT,
    @Package        INT,
    @PriorityNumber INT,
    @IsCurrentFlag  VARCHAR(1),
    @CurrentVersion INT,
    @StartTime      DATETIME,
    @EndTime        DATETIME
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRC_STOREPACKAGE
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        STORE,
        PACKAGE,
        PRIORITY_NO,
        ISCURRENT_FL,
        CURRENTVERSION,
        START_TM,
        END_TM
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Store,
        @Package,
        @PriorityNumber,
        @IsCurrentFlag,
        @CurrentVersion,
        @StartTime,
        @EndTime
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @StorePackageId = SCOPE_IDENTITY();
/*Section="End"*/
END;
