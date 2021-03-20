CREATE PROCEDURE [dbo].[PadronElectoralInsertar]
    @Cedula VARCHAR(15),
	@Nombre VARCHAR(50),
	@Apellido1 VARCHAR(150),
	@Apellido2 VARCHAR(150),
	@Edad INT,
	@Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
		INSERT INTO dbo.PadronElectoral
		(
			Cedula,
			Nombre,
			Apellido1,
			Apellido2,
			Edad,
			Estado
		)
		VALUES
		(
			@Cedula,
			@Nombre,
			@Apellido1,
			@Apellido2,
			@Edad,
			@Estado
		)


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
