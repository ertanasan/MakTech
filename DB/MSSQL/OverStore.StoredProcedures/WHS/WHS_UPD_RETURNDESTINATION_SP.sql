-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_RETURNDESTINATION_SP
    @ReturnDestinationId INT,
    @DestinationName     VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_RETURNDESTINATIONLOG
    (
        RETURNDESTINATIONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        DESTINATION_NM
    )    
    SELECT
        RETURNDESTINATIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        DESTINATION_NM
      FROM
        WHS_RETURNDESTINATION R (NOLOCK)
     WHERE
        R.RETURNDESTINATIONID = @ReturnDestinationId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_RETURNDESTINATION
       SET
           DESTINATION_NM = @DestinationName
     WHERE RETURNDESTINATIONID = @ReturnDestinationId;

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
