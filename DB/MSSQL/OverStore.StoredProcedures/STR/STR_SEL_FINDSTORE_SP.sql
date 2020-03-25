-- Created by OverGenerator  
/*Section="Main"*/  
CREATE  PROCEDURE STR_SEL_FINDSTORE_SP 
	 @Branch INT = NULL  
AS  
BEGIN  
    DECLARE @Organization INT, @BranchTypeName VARCHAR, @OldestStoreBranchID INT;  
	
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();  
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1  
    BEGIN  
      SET @Organization = null;  
    END 


	--SELECT @BranchTypeName = BT.BRANCHTYPE_NM FROM ORG_BRANCHTYPE BT (NOLOCK) WHERE BRANCHTYPEID = (SELECT B.BRANCHTYPE FROM ORG_BRANCH B WHERE BRANCHID = @Branch);
	--Gelen branch kodunun tipi branch'ten farklıysa, yani GM veya BM ise o zaman en eski mağazanın branch kodunu bulup bu mağazanın fiyatlarını dönelim.
	--IF ISNULL(@BranchTypeName, '') != 'Branch' 
	--BEGIN
	--	SELECT @Branch = BRANCH FROM STR_STORE S WHERE S.STOREID  = (SELECT MIN(STOREID) FROM STR_STORE SS WHERE DELETED_FL = 'N' AND SS.ACTIVE_FL = 'Y' AND SS.BRANCH IS NOT NULL)
	--END

    SELECT  
           S.STOREID,  
           S.ORGANIZATION,  
           S.DELETED_FL,  
           S.CREATE_DT,  
           S.UPDATE_DT,  
           S.CREATEUSER,  
           S.UPDATEUSER,  
           S.STORE_NM,  
           S.BRANCH,  
           S.IPADDRESS_TXT,  
           S.ADVANCE_AMT,  
           S.OPENING_DT,  
           S.CLOSING_DT,  
           S.ACTIVE_FL,  
           S.PRODUCTION_FL,  
           S.CITY,  
           S.TOWN,  
           S.ADDRESS_TXT,  
           S.REGIONMANAGER,  
           S.INCONSTRUCTION_FL  
      FROM STR_STORE S (NOLOCK)  
     WHERE S.BRANCH = @Branch
		AND s.DELETED_FL = 'N'
		AND S.ACTIVE_FL = 'Y';
END;  