-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_SHIPMENTSCHEDULE_SP
    @ShipmentScheduleId   INT OUT,
    @ShipmentScheduleName VARCHAR(100),
    @Store                INT,
    @ScheduleDetail       VARCHAR(1000),
    @Comment              VARCHAR(200)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_SHIPMENTSCHEDULE
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        SHIPMENTSCHEDULE_NM,
        STORE,
        SCHEDULE_TXT,
        COMMENT_DSC
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @ShipmentScheduleName,
        @Store,
        @ScheduleDetail,
        @Comment
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
    SELECT @ShipmentScheduleId = SCOPE_IDENTITY();
/*Section="End"*/
END;
