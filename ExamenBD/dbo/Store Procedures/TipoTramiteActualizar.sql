CREATE PROCEDURE [dbo].[TipoTramiteActualizar]
	 @IdTipoTramite INT,
    @Descripcion VARCHAR(256),
	@Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE DBO.Tramite SET
	Descripcion=@Descripcion,
	Estado=@Estado

	WHERE IdTipoTramite=@IdTipoTramite


		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END
