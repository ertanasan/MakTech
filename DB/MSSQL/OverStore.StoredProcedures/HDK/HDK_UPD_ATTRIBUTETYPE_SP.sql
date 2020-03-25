-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_ATTRIBUTETYPE_SP
    @AttributeTypeId   INT,
    @AttributeTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_ATTRIBUTETYPELOG
    (
        ATTRIBUTETYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ATTRIBUTETYPE_NM
    )    
    SELECT
        ATTRIBUTETYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ATTRIBUTETYPE_NM
      FROM
        HDK_ATTRIBUTETYPE A (NOLOCK)
     WHERE
        A.ATTRIBUTETYPEID = @AttributeTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE HDK_ATTRIBUTETYPE
       SET
           ATTRIBUTETYPE_NM = @AttributeTypeName
     WHERE ATTRIBUTETYPEID = @AttributeTypeId;

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
