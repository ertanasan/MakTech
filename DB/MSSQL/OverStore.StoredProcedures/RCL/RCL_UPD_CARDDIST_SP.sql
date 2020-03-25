-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_UPD_CARDDIST_SP
    @CardDistributionId BIGINT,
    @Event              INT,
    @Organization       INT,
    @CardGroupCode      INT,
    @CardZetAmount      NUMERIC(22,6),
    @StoreRec           BIGINT
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
    UPDATE RCL_CARDDIST
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           CARDGROUP_CD = @CardGroupCode,
           CARDZET_AMT = @CardZetAmount,
           STOREREC = @StoreRec
     WHERE CARDDISTID = @CardDistributionId     
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
