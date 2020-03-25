/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_TRANSFERPRODUCT_SP
    @TransferProductId BIGINT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

	DECLARE @PreviousComment VARCHAR(4000);  
	 SELECT TOP(1) @PreviousComment = USERCOMMENT_DSC   
	   FROM BPA_ACTION   
	  WHERE PROCESSINSTANCE = (SELECT PROCESSINSTANCE_LNO FROM WHS_TRANSFERPRODUCT WHERE TRANSFERPRODUCTID = @TransferProductId)  
	    AND CHOICE_TXT IS NOT NULL  
   ORDER BY CREATE_DT DESC; 

    /*Section="Query"*/
    -- Select
    SELECT
           T.TRANSFERPRODUCTID,
           T.EVENT,
           T.ORGANIZATION,
           T.DELETED_FL,
           T.CREATE_DT,
           T.UPDATE_DT,
           T.CREATEUSER,
           T.UPDATEUSER,
           T.CREATECHANNEL,
           T.CREATEBRANCH,
           T.CREATESCREEN,
           T.SOURCESTORE,
           T.DESTINATIONSTORE,
           T.PROCESSINSTANCE_LNO,
           T.TRANSFERSTATUS,
		   @PreviousComment PREVIOUSCOMMENT_DSC,
           T.WAYBILL_TXT,
		   T.RETURNDESTINATION
      FROM WHS_TRANSFERPRODUCT T (NOLOCK)
     WHERE T.TRANSFERPRODUCTID = @TransferProductId
       AND (@Organization IS NULL OR T.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
