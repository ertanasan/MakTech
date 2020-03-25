-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_INS_SUGGESTION_SP
    @SuggestionId         BIGINT OUT,
    @Event                INT,
    @Organization         INT,
    @SuggestionText       VARCHAR(2000),
    @ProcessInstance      BIGINT,
    @Status               INT,
    @Type                 INT,
    @InnovativenessRating NUMERIC(4,2),
    @FeasibilityRating    NUMERIC(4,2),
    @AddedValueRating     NUMERIC(4,2)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ANN_SUGGESTION
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        SUGGESTION_TXT,
        PROCESSINSTANCE_LNO,
        STATUS,
        TYPE,
        INNOVATIVENESS_RT,
        FEASIBILITY_RT,
        ADDEDVALUE_RT
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
        @SuggestionText,
        @ProcessInstance,
        @Status,
        @Type,
        @InnovativenessRating,
        @FeasibilityRating,
        @AddedValueRating
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
    SELECT @SuggestionId = SCOPE_IDENTITY();
/*Section="End"*/
END;
