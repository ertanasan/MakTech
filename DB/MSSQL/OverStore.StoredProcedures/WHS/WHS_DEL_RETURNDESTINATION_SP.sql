-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_RETURNDESTINATION_SP
    @ReturnDestinationId INT
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
        DESTINATION_NM    )    
    SELECT
        RETURNDESTINATIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        DESTINATION_NM
      FROM
        WHS_RETURNDESTINATION R (NOLOCK)
     WHERE
        R.RETURNDESTINATIONID = @ReturnDestinationId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_RETURNDESTINATION
     WHERE RETURNDESTINATIONID = @ReturnDestinationId;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
