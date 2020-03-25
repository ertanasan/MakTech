-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_INS_SALERAW_SP
    @SaleRawId    BIGINT OUT,
    @Event        INT,
    @Organization INT,
    @SaleID       BIGINT,
    @Line         VARCHAR(1000),
    @Position     INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO SLS_SALERAW
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        SALE,
        LINE_TXT,
        POSITION_NO
    )
    VALUES
    (
        1045, -- @Event,
        1, -- @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @SaleID,
        @Line,
        @Position
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
    SELECT @SaleRawId = SCOPE_IDENTITY();
/*Section="End"*/
END;
