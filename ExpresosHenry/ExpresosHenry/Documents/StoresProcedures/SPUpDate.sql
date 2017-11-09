IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPUpDate]') AND type in (N'P', N'PC'))
EXEC ('CREATE PROCEDURE [dbo].[SPUpDate] AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROCEDURE [dbo].[SPUpDate] @pisTabla AS VARCHAR(MAX),@pisCampos VARCHAR(MAX),@pisDatos VARCHAR(MAX) ,
@pisWhere VARCHAR (MAX), @pobRespuesta AS BIT OUTPUT, @posRespuesta VARCHAR(MAX) = '' OUTPUT AS 

CREATE TABLE #DatosUpdate (id int,campo VARCHAR(MAX),dato VARCHAR(MAX))
DECLARE @PosicionCam INT
DECLARE @PosicionDat INT
DECLARE @id INT
DECLARE @count INT
DECLARE @campo VARCHAR(MAX)
DECLARE @dato VARCHAR(MAX)
DECLARE @vl_sSQl VARCHAR(MAX)


SET NOCOUNT ON

BEGIN TRY

SET @pisCampos = @pisCampos + ','
SET @pisDatos = @pisDatos + ','
SET @id=1


WHILE patindex('%,%' , @pisDatos) <> 0 AND patindex('%,%' , @pisCampos) <> 0
BEGIN
  SELECT @PosicionCam =  patindex('%,%' , @pisCampos)
  SELECT @PosicionDat =  patindex('%,%' , @pisDatos)
  SELECT @campo = left(@pisCampos, @PosicionCam - 1)
  SELECT @dato = left(@pisDatos, @PosicionDat - 1)
  INSERT INTO #DatosUpdate VALUES (@id,@campo,@dato)
  SELECT @pisCampos = stuff(@pisCampos, 1, @PosicionCam, '')
  SELECT @pisDatos = stuff(@pisDatos, 1, @PosicionDat, '')
  SELECT @id=@id+1
END
SELECT @count=count(*)FROM #DatosUpdate 


/*Armamos el update*/
SET @vl_sSQl = 'UPDATE '+ @pisTabla + ' SET' 
SET @id=1

while @id<=@count
BEGIN
	SELECT 	@campo = campo,@dato = dato FROM #DatosUpdate WHERE id = @id
	SET @vl_sSQl = @vl_sSQl +' '+ @campo +' = '+ @dato
	IF @id < @count
	BEGIN
		SET @vl_sSQl = @vl_sSQl + ', ' 
	END 
	SELECT @id=@id+1
END 
SET @vl_sSQl = @vl_sSQl + ' ' +@pisWhere

print(@pisWhere)
print (@vl_sSQL)

EXEC (@vl_sSQL)
SET @pobRespuesta = 1
    END TRY
    BEGIN CATCH
	    SET @posRespuesta = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ', SPUpDate.'		
        SET @pobRespuesta = 0
    END CATCH
SET NOCOUNT OFF
GO