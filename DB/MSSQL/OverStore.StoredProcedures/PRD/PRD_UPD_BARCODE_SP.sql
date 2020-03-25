/*Section="Main"*/
CREATE PROCEDURE [dbo].[PRD_UPD_BARCODE_SP]
    @ProductBarcodeId INT,
    @Product          INT,
    @BarcodeType      INT,
    @BarcodeText      VARCHAR(1000)
AS
BEGIN
    INSERT INTO PRD_BARCODELOG	
	  (BARCODEID
		, LOG_DT
		, LOGUSER
		, LOGOPERATION_CD
		, LOGCHANNEL
		, LOGBRANCH
		, LOGSCREEN
		, PRODUCT
		, BARCODETYPE
		, BARCODE_TXT)
	  SELECT  B.BARCODEID,	GETDATE(),  dbo.SYS_GETCURRENTUSER_FN(),  'UPD',  dbo.SYS_GETCURRENTCHANNEL_FN(),  
			  dbo.SYS_GETCURRENTBRANCH_FN(),  dbo.SYS_GETCURRENTSCREEN_FN(),  B.PRODUCT,
			  B.BARCODETYPE, B.BARCODE_TXT
	     FROM PRD_BARCODE B (NOLOCK)  
        WHERE B.BARCODEID = @ProductBarcodeId;   


    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_BARCODE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           PRODUCT = @Product,
           BARCODETYPE = @BarcodeType,
           BARCODE_TXT = @BarcodeText
     WHERE BARCODEID = @ProductBarcodeId

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
