CREATE PROCEDURE PRC_UPD_PACKAGEVERSION_SP  
    @PackageVersionId INT,  
    @Package          INT,  
    @VersionDate      DATETIME,  
    @ActiveFlag       VARCHAR(1),  
    @Comment          VARCHAR(1000),  
    @ActivationTime   DATETIME  
AS  
BEGIN  

	-- Sadece son version update edilebilir.
	DECLARE @MaxVersionId INT
	SELECT @MaxVersionId = MAX(PACKAGEVERSIONID) FROM PRC_PACKAGEVERSION WHERE PACKAGE = @Package AND DELETED_FL = 'N'

	IF (@MaxVersionId != @PackageVersionId)
	BEGIN
		THROW 100001, 'Sadece son versiyon güncellenebilir.', 1;  
        RETURN;  
	END;

	-- Versiyon aktife çekiliyorsa diğerlerinin pasif olması gerekir. 
	IF (@ActiveFlag = 'Y') 
	BEGIN
		UPDATE PRC_PACKAGEVERSION SET ACTIVE_FL = 'N' WHERE PACKAGE = @Package;
	END;
  
    SET NOCOUNT OFF;  
    -- Update record  
    UPDATE PRC_PACKAGEVERSION  
       SET UPDATE_DT = GETDATE(),  
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),  
           PACKAGE = @Package,  
           VERSION_DT = @VersionDate,  
           ACTIVE_FL = @ActiveFlag,  
           COMMENT_DSC = @Comment,  
           ACTIVATION_TM = @ActivationTime  
     WHERE PACKAGEVERSIONID = @PackageVersionId;  
  
    -- Check the updated row count  
    IF @@ROWCOUNT = 0  
    BEGIN  
        SET NOCOUNT ON;  
        THROW 100001, 'Nothing to update. Update failed.', 1;  
        RETURN;  
    END;  
    SET NOCOUNT ON;  
  

END;  