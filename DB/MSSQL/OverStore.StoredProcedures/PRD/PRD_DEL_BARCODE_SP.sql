-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE [dbo].[PRD_DEL_BARCODE_SP]
    @ProductBarcodeId INT
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
	  SELECT  B.BARCODEID,	GETDATE(),  dbo.SYS_GETCURRENTUSER_FN(),  'DEL',  dbo.SYS_GETCURRENTCHANNEL_FN(),  
			  dbo.SYS_GETCURRENTBRANCH_FN(),  dbo.SYS_GETCURRENTSCREEN_FN(),  B.PRODUCT,
			  B.BARCODETYPE, B.BARCODE_TXT
	     FROM PRD_BARCODE B (NOLOCK)  
        WHERE B.BARCODEID = @ProductBarcodeId;  

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE PRD_BARCODE
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE BARCODEID = @ProductBarcodeId

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
