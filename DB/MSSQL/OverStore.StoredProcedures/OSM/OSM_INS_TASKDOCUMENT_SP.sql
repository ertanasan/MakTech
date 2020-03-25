-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_INS_TASKDOCUMENT_SP
    @OverStoreTask BIGINT,
    @Document      BIGINT
AS
BEGIN
    /*Section="Insert"*/
    -- Insert record
    SET NOCOUNT OFF
    INSERT INTO OSM_TASKDOCUMENT
    (
        TASK,
        DOCUMENT,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN
    )
    VALUES
    (
        @OverStoreTask,
        @Document,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN()
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
END;
