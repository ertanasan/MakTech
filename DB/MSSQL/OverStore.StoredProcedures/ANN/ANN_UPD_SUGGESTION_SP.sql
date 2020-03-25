-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_UPD_SUGGESTION_SP
    @SuggestionId         BIGINT,
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
    UPDATE ANN_SUGGESTION
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SUGGESTION_TXT = @SuggestionText,
           PROCESSINSTANCE_LNO = @ProcessInstance,
           STATUS = @Status,
           TYPE = @Type,
           INNOVATIVENESS_RT = @InnovativenessRating,
           FEASIBILITY_RT = @FeasibilityRating,
           ADDEDVALUE_RT = @AddedValueRating
     WHERE SUGGESTIONID = @SuggestionId
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
