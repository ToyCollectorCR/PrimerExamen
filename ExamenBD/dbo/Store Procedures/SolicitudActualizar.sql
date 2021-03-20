CREATE PROCEDURE [dbo].[SolicitudActualizar]
	@IdSolicitud INT,
	@IdCivil INT,
	@IdTipoTramite INT,
	@Detalle varchar(1000),
	@Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE DBO.Solicitud SET
	
	IdCivil=@IdCivil,
	IdTipoTramite=@IdTipoTramite,
	Detalle=@Detalle,
	Estado=@Estado
	WHERE IdSolicitud =@IdSolicitud 


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