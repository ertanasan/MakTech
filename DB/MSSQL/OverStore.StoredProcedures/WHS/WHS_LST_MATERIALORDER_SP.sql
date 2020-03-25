CREATE PROCEDURE WHS_LST_MATERIALORDER_SP @StartDate DATE = NULL, @AllRecords VARCHAR(1) = 'N' AS
BEGIN
    
    SET @StartDate = ISNULL(@StartDate, CAST(GETDATE() - 30 AS DATE));
	IF OBJECT_ID('tempdb.dbo.#STORES', 'U') IS NOT NULL DROP TABLE #STORES;
	SELECT * INTO #STORES FROM dbo.STR_GETUSERSTORES_FN();

    DECLARE @Depot VARCHAR(1);
	SELECT @Depot = CASE WHEN DEPARTMENT_NM = 'Merkez Depo' THEN 'Y' ELSE 'N' END
	  FROM SEC_USER U
	  JOIN ORG_DEPARTMENT D ON U.DEPARTMENT = D.DEPARTMENTID
	 WHERE U.USERID = dbo.SYS_GETCURRENTUSER_FN();

    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      SET @Organization = null;
    END

    SELECT
           M.MATERIALORDERID,
           M.EVENT,
           M.ORGANIZATION,
           M.DELETED_FL,
           M.CREATE_DT,
           M.UPDATE_DT,
           M.CREATEUSER,
           M.UPDATEUSER,
           M.CREATECHANNEL,
           M.CREATEBRANCH,
           M.CREATESCREEN,
           M.ORDER_NM,
           M.ORDER_DT,
           M.ORDERSTATUS_CD,
           M.STORE,
           M.PROCESSINSTANCE_LNO,
           M.MIKROSTATUS_CD,
           M.MIKROREF_TXT,
           M.MIKRO_TM,
           M.MIKROUSER,
           M.MATERIAL,
           M.MATERIALINFO,
           M.ORDER_AMT,
           M.REVISED_AMT,
           M.SHIPPED_AMT,
           M.INTAKE_AMT,
           M.NOTE_TXT
      FROM WHS_MATERIALORDER M (NOLOCK)
      JOIN #STORES S ON M.STORE = S.STOREID
     WHERE (@Organization IS NULL OR M.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
       AND M.ORDER_DT >= @StartDate
       AND (@AllRecords = 'Y' OR M.ORDERSTATUS_CD < 5)
       AND (@Depot = 'N' OR M.ORDERSTATUS_CD > 2);

END;
