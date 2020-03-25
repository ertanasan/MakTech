-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_REQADDITIONALINFO_SP
    @RequestAdditionalInfoId BIGINT OUT,
    @Event                   INT,
    @Organization            INT,
    @Request                 BIGINT,
    @Cost                    NUMERIC(22,6),
    @WarrantyDueDate         DATETIME,
    @Folder                  BIGINT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_REQADDITIONALINFO
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        REQUEST,
        COST_AMT,
        WARRANTYDUE_DT,
        FOLDER
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Request,
        @Cost,
        @WarrantyDueDate,
        @Folder
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
    SELECT @RequestAdditionalInfoId = SCOPE_IDENTITY();
/*Section="End"*/
END;
