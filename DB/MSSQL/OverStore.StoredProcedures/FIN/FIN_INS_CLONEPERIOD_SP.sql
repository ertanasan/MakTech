CREATE PROCEDURE [dbo].[FIN_INS_CLONEPERIOD_SP]
	@TemplateRecordId BIGINT, @ClonedRecordId BIGINT OUT
AS
	/*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
	INSERT INTO FIN_ESTATERENTPERIOD 
	(
		   ORGANIZATION, 
		   DELETED_FL, 
		   CREATE_DT, 
		   CREATEUSER, 
		   ESTATERENT, 
		   PERIODORDER_NO, 
		   START_DT, 
		   END_DT, 
		   CONTRACTRENT_AMT, 
		   CONTRACTRENTCURRENCY_TXT, 
		   ADDITIONALRENT_AMT, 
		   ADDRENTCURRENCY_TXT
	)
	SELECT ORGANIZATION,
		   'N',
		   GETDATE(),
		   dbo.SYS_GETCURRENTUSER_FN(),
		   ESTATERENT,
		   PERIODORDER_NO + 1,
		   DATEADD(YEAR, 1, START_DT), 
		   DATEADD(YEAR, 1, END_DT),
		   CONTRACTRENT_AMT,
		   CONTRACTRENTCURRENCY_TXT,
		   ADDITIONALRENT_AMT,
		   ADDRENTCURRENCY_TXT
	  FROM FIN_ESTATERENTPERIOD RP
	 WHERE RP.ESTATERENTPERIODID = @TemplateRecordId;

	 /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @ClonedRecordId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO FIN_ESTATERENTPERIODLOG
    (
            ESTATERENTPERIODID,
            LOG_DT,
            LOGUSER,
            LOGOPERATION_CD,
            LOGCHANNEL,
            LOGBRANCH,
            LOGSCREEN,
            ESTATERENT,
            PERIODORDER_NO,
            START_DT,
            END_DT,
            CONTRACTRENT_AMT,
            CONTRACTRENTCURRENCY_TXT,
            ADDITIONALRENT_AMT,
            ADDRENTCURRENCY_TXT
    )
    SELECT
            @ClonedRecordId,
            GETDATE(),
            dbo.SYS_GETCURRENTUSER_FN(),
            'INS',
            dbo.SYS_GETCURRENTCHANNEL_FN(),
            dbo.SYS_GETCURRENTBRANCH_FN(),
            dbo.SYS_GETCURRENTSCREEN_FN(),
            ESTATERENT,
		    PERIODORDER_NO,
		    START_DT, 
		    END_DT,
		    CONTRACTRENT_AMT,
		    CONTRACTRENTCURRENCY_TXT,
		    ADDITIONALRENT_AMT,
		    ADDRENTCURRENCY_TXT
       FROM FIN_ESTATERENTPERIOD RP
      WHERE RP.ESTATERENTPERIODID = @ClonedRecordId;
/*Section="End"*/

