﻿CREATE PROCEDURE SEC_LST_USERSCREENS_SP @User INT, @Program INT = 2 AS      
BEGIN   

DECLARE @LanguageId INT = 3;  -- Language = TURKCE
  
IF @User = -1  
 SELECT S.SCREENID, COALESCE(TR2.LOCAL_TXT, TR2.GLOBAL_TXT, S.SCREEN_NM) SCREEN_NM 
 FROM PRG_SCREEN S
 LEFT JOIN PRG_MENU MN ON MN.SCREEN = S.SCREENID
 LEFT JOIN PRM_TEXTRESOURCE TR2 ON MN.CAPTION_NM = TR2.GLOBAL_TXT AND TR2.[LANGUAGE] = @LanguageId 
 WHERE S.PROGRAM = @Program AND S.DELETED_FL = 'N'
 ORDER BY 2;

ELSE     
-- TMP TABLES      
IF OBJECT_ID('tempdb.dbo.#groups', 'U') IS NOT NULL DROP TABLE #groups      
IF OBJECT_ID('tempdb.dbo.#roles', 'U') IS NOT NULL DROP TABLE #roles      
IF OBJECT_ID('tempdb.dbo.#privileges', 'U') IS NOT NULL DROP TABLE #privileges      
IF OBJECT_ID('tempdb.dbo.#screenDetails', 'U') IS NOT NULL DROP TABLE #screenDetails;      
      
-- GETTING USER GROUPS      
WITH GroupCTE AS            
 (             
  SELECT GU.CONTAINERGROUP           
    FROM SEC_GROUPUSER GU             
 JOIN SEC_USER U ON U.USERID = GU.MEMBERUSER      
   WHERE U.USERID = @User      
   UNION ALL            
  SELECT GG.MEMBERGROUP              
    FROM SEC_GROUPGROUP GG        
    JOIN GroupCTE CT ON GG.CONTAINERGROUP  = CT.CONTAINERGROUP             
 )       
SELECT CONTAINERGROUP INTO #groups FROM GroupCTE      
      
-- GETTING GROUP ROLERS      
SELECT DISTINCT GR.ROLE      
INTO #roles      
FROM SEC_GROUPROLE GR       
JOIN #groups G ON G.CONTAINERGROUP = GR.[GROUP];      
      
-- GETTING ROLE PRIVILEGES      
WITH PrivilegeCTE AS            
 (             
  SELECT RP.PRIVILEGE, P.PARENT            
    FROM SEC_ROLEPRIVILEGE RP            
 JOIN SEC_PRIVILEGE P ON P.PRIVILEGEID = RP.PRIVILEGE      
   WHERE RP.ROLE IN (SELECT R.ROLE FROM #roles R)            
   UNION ALL            
  SELECT P.PRIVILEGEID, P.PARENT              
    FROM SEC_PRIVILEGE P         
    JOIN PrivilegeCTE CT ON P.PARENT = CT.PRIVILEGE             
 ) SELECT PRIVILEGE INTO #privileges FROM PrivilegeCTE      
      
-- GETTING SCREEN / MENU / MODULE DETAIL & PRIVILEGES & ACTIONS       
SELECT SA.SCREEN
, COALESCE(TR2.LOCAL_TXT, TR2.GLOBAL_TXT, S.SCREEN_NM) SCREEN_NM
, COALESCE(TR1.LOCAL_TXT, TR1.GLOBAL_TXT, M.MODULE_NM) MODULE_NM      
, CASE WHEN MN.CAPTION_NM IS NULL THEN 'None / Embeded Screen' ELSE COALESCE(TR3.LOCAL_TXT, TR3.GLOBAL_TXT, MN.CAPTION_NM) END MENU      
--, CASE WHEN SA.[ACTION] IS NULL THEN 1000 ELSE SA.[ACTION] END [ACTION]      
, CASE WHEN P.PRIVILEGE IS NULL THEN 0 ELSE 1 END HASPRIVILEGE      
, SA.[ACTION]       
INTO #screenDetails      
FROM PRG_SCREEN S      
JOIN PRG_SCREENACTION SA ON S.SCREENID = SA.SCREEN      
JOIN PRG_MODULE M ON M.MODULEID = S.MODULE
LEFT JOIN PRM_TEXTRESOURCE TR1 ON M.MODULE_NM = TR1.GLOBAL_TXT AND TR1.[LANGUAGE] = @LanguageId 
LEFT JOIN PRG_MENU MN ON MN.SCREEN = S.SCREENID
LEFT JOIN PRM_TEXTRESOURCE TR2 ON MN.CAPTION_NM = TR2.GLOBAL_TXT AND TR2.[LANGUAGE] = @LanguageId 
LEFT JOIN PRG_MENU MN2 ON MN.PARENT = MN.MENUID
LEFT JOIN PRM_TEXTRESOURCE TR3 ON MN2.CAPTION_NM = TR3.GLOBAL_TXT AND TR3.[LANGUAGE] = @LanguageId
LEFT JOIN #privileges P  ON SA.PRIVILEGE = P.PRIVILEGE      
WHERE S.PROGRAM = @Program      
  AND S.DELETED_FL = 'N'      
      
-- MAIN QUERIES (DIFFERS FOR EACH PROGRAM)      
IF @Program = 2      
BEGIN      
WITH screens AS (
SELECT SD.SCREEN, SD.SCREEN_NM, SD.MODULE_NM, SD.MENU      
, MAX(SD.HASPRIVILEGE)  [HASPRIVILEGE]      
, MAX(CASE WHEN SD.[ACTION] = 20 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Index]      
, MAX(CASE WHEN SD.[ACTION] = 22 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Create]      
, MAX(CASE WHEN SD.[ACTION] = 46 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [AddRight]      
, MAX(CASE WHEN SD.[ACTION] = 47 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [AddLeft]      
, MAX(CASE WHEN SD.[ACTION] = 23 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Update]      
, MAX(CASE WHEN SD.[ACTION] = 24 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Delete]      
, MAX(CASE WHEN SD.[ACTION] = 21 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Read]      
, MAX(CASE WHEN SD.[ACTION] = 25 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [List]      
, MAX(CASE WHEN SD.[ACTION] = 26 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [GetReport]      
--, MAX(CASE WHEN SD.[ACTION] = 1000 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [CustomPrivilege]      
FROM #screenDetails SD      
GROUP BY SD.SCREEN, SD.SCREEN_NM, SD.MODULE_NM, SD.MENU )
SELECT * FROM screens s
WHERE s.[Index] =1 OR s.[Create]=1 OR s.[AddRight]=1 OR s.[AddLeft]=1 OR s.[Update]=1 OR s.[Delete]=1 OR s.[Read]=1 OR s.[List]=1 OR s.[GetReport]=1
ORDER BY SCREEN_NM      
END      
      
ELSE IF @Program = 1      
BEGIN      
SELECT SD.SCREEN, SD.SCREEN_NM, SD.MODULE_NM, SD.MENU      
, MAX(SD.HASPRIVILEGE)  [HASPRIVILEGE]      
, MAX(CASE WHEN SD.[ACTION] = 1  THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [AccountLogin]      
, MAX(CASE WHEN SD.[ACTION] = 2  THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [AccountLogoff]      
, MAX(CASE WHEN SD.[ACTION] = 3  THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Index]      
, MAX(CASE WHEN SD.[ACTION] = 4  THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Create]      
, MAX(CASE WHEN SD.[ACTION] = 9  THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [AddRight]      
, MAX(CASE WHEN SD.[ACTION] = 10 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [AddLeft]      
, MAX(CASE WHEN SD.[ACTION] = 11 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [CreateDetail]      
, MAX(CASE WHEN SD.[ACTION] = 15 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [SaveAttachment]      
, MAX(CASE WHEN SD.[ACTION] = 6  THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Update]      
, MAX(CASE WHEN SD.[ACTION] = 12 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [UpdateDetail]      
, MAX(CASE WHEN SD.[ACTION] = 7  THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Delete]      
, MAX(CASE WHEN SD.[ACTION] = 16 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [RemoveAttachment]      
, MAX(CASE WHEN SD.[ACTION] = 5  THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Read]      
, MAX(CASE WHEN SD.[ACTION] = 13 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [ReadImageOfSession]      
, MAX(CASE WHEN SD.[ACTION] = 8  THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [List]      
, MAX(CASE WHEN SD.[ACTION] = 18 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [ListDocumentsOfSession]      
, MAX(CASE WHEN SD.[ACTION] = 14 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [ListDocumentsOfFolder]      
, MAX(CASE WHEN SD.[ACTION] = 17 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [DownloadAttachment]      
, MAX(CASE WHEN SD.[ACTION] = 19 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [GetReport]      
--, MAX(CASE WHEN SD.[ACTION] = 1000 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [CustomPrivilege]      
FROM #screenDetails SD      
GROUP BY SD.SCREEN, SD.SCREEN_NM, SD.MODULE_NM, SD.MENU      
ORDER BY SD.SCREEN_NM      
END      
      
      
ELSE -- @Program = 3      
BEGIN       
SELECT SD.SCREEN, SD.SCREEN_NM, SD.MODULE_NM, SD.MENU      
, MAX(SD.HASPRIVILEGE)  [HASPRIVILEGE]      
, MAX(CASE WHEN SD.[ACTION] = 37 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Login]      
, MAX(CASE WHEN SD.[ACTION] = 38 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Logoff]      
, MAX(CASE WHEN SD.[ACTION] = 32 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Index]      
, MAX(CASE WHEN SD.[ACTION] = 27 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Create]      
, MAX(CASE WHEN SD.[ACTION] = 35 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [AddRight]      
, MAX(CASE WHEN SD.[ACTION] = 34 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [AddLeft]      
, MAX(CASE WHEN SD.[ACTION] = 36 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [CreateDetail]      
, MAX(CASE WHEN SD.[ACTION] = 33 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [UpdateDetail]      
, MAX(CASE WHEN SD.[ACTION] = 29 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Update]      
, MAX(CASE WHEN SD.[ACTION] = 30 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Delete]      
, MAX(CASE WHEN SD.[ACTION] = 28 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [Read]      
, MAX(CASE WHEN SD.[ACTION] = 31 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [List]      
--, MAX(CASE WHEN SD.[ACTION] = 1000 THEN (CASE WHEN SD.HASPRIVILEGE = 1 THEN 1 ELSE 0 END) ELSE -9 END) [CustomPrivilege]      
FROM #screenDetails SD      
GROUP BY SD.SCREEN, SD.SCREEN_NM, SD.MODULE_NM, SD.MENU      
ORDER BY SD.SCREEN_NM      
END      
      
END