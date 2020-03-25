CREATE PROCEDURE [dbo].[WHS_INS_LOGCONTROLZERO_SP]
	@GatheringPalletId BIGINT,
	@GatheringDetailId BIGINT,
	@PreviousQuantity  NUMERIC(12,6) = NULL
AS
BEGIN
    INSERT INTO WHS_GATHERINGCONTROLZERO
    (
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        GATHERINGPALLET,
        GATHERINGDETAIL,
        PREVIOUS_QTY
    )
    VALUES
    (
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @GatheringPalletId,
        @GatheringDetailId,
        @PreviousQuantity
    );
END;