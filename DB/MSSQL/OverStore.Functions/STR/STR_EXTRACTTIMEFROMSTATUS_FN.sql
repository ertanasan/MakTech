CREATE FUNCTION STR_EXTRACTTIMEFROMSTATUS_FN (@StatusText VARCHAR(100), @DeviceType VARCHAR(100)) RETURNS DATETIME AS
BEGIN
  DECLARE @yeartext VARCHAR(100) = CAST(DATEPART(YEAR, GETDATE()) AS varchar)+'-'
  DECLARE @resultTxt VARCHAR(100), @result DATETIME
  DECLARE @txt VARCHAR(20) 
  IF @DeviceType = 'Digi' 
  BEGIN
    SET @resultTxt = @yeartext+RIGHT(@StatusText, 11)+':00.000';
  END ELSE IF @DeviceType = 'Densi' 
  BEGIN
    SET @txt = RIGHT(@StatusText, 14)
	SET @resultTxt = @yeartext+REPLACE(LEFT(@txt, 7),' ','')+' '+REPLACE(RIGHT(@txt, 6),' ','')+':00.000';
  END ELSE IF @DeviceType = 'Wincor' 
  BEGIN
	SET @txt = CONVERT(VARCHAR(20),CONVERT(DATE,LEFT(@StatusText,10),104),120)
	SET @resultTxt = @txt+' '+SUBSTRING(@StatusText,12,5)+':00.000';
  END
  IF len(@resultTxt) = 23
  BEGIN
	SET @result = CONVERT(DATETIME, @resultTxt, 120)
  END
  RETURN @result
END