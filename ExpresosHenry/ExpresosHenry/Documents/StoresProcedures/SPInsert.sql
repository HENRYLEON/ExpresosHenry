IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPInsert]') AND type in (N'P', N'PC'))
EXEC ('CREATE PROCEDURE [dbo].[SPInsert] AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROCEDURE [dbo].[SPInsert] @pisTabla AS VARCHAR(MAX), @pisDatos VARCHAR(MAX) ,@pobRespuesta BIT OUTPUT, @posRespuesta VARCHAR(MAX) = '' OUTPUT AS 
BEGIN

DECLARE @vl_sSql VARCHAR(MAX)
    SET NOCOUNT ON;
    BEGIN TRY
        SET @vl_sSql = 'INSERT INTO ' + @pisTabla + '   VALUES ('+@pisDatos+')'
		PRINT(@vl_sSql)
		EXEC (@vl_sSql)
        SET @pobRespuesta = 1
    END TRY
    BEGIN CATCH
        SET @pobRespuesta = 0
		SET @posRespuesta = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ', SPInsert.'
    END CATCH
END