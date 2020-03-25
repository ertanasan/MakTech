/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_SUGGESTION_SP
    @SuggestionId BIGINT
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

    /*Section="Query"*/
	-- Get last action comment
	DECLARE @PreviousActionComment VARCHAR(4000);
	 SELECT TOP(1) @PreviousActionComment = ISNULL(A.USERCOMMENT_DSC, ' ')
	   FROM BPA_ACTION A
	   JOIN ANN_SUGGESTION S ON A.PROCESSINSTANCE = S.PROCESSINSTANCE_LNO
	  WHERE S.SUGGESTIONID = @SuggestionId
	    AND A.CHOICE_TXT IS NOT NULL
      ORDER BY A.CREATE_DT DESC; 

    SELECT S.SUGGESTIONID,
           S.EVENT,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.CREATECHANNEL,
           S.CREATEBRANCH,
           S.CREATESCREEN,
           S.SUGGESTION_TXT,
           S.PROCESSINSTANCE_LNO,
		   B.BRANCH_NM,
           S.STATUS,
           S.TYPE,
           S.INNOVATIVENESS_RT,
           S.FEASIBILITY_RT,
           S.ADDEDVALUE_RT,
		   @PreviousActionComment PREVIOUSACTIONCOMMENT_DSC
      FROM ANN_SUGGESTION S (NOLOCK)
	  JOIN SEC_USER U ON U.USERID = S.CREATEUSER
   	  JOIN ORG_BRANCH B ON B.BRANCHID = U.BRANCH
     WHERE S.DELETED_FL = 'N'
	   AND S.SUGGESTIONID = @SuggestionId
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
