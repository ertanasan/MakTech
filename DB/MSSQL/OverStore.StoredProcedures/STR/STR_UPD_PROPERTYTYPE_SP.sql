-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_PROPERTYTYPE_SP
    @StorePropertyId INT,
    @PropertyName    VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_PROPERTYTYPELOG
    (
        PROPERTYTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROPERTYTYPE_NM
    )
    SELECT
        PROPERTYTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROPERTYTYPE_NM
      FROM
        STR_PROPERTYTYPE P (NOLOCK)
     WHERE
        P.PROPERTYTYPEID = @StorePropertyId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_PROPERTYTYPE
       SET
           PROPERTYTYPE_NM = @PropertyName
     WHERE PROPERTYTYPEID = @StorePropertyId;

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
