CREATE PROCEDURE [dbo].[PadronElectoralActualizar]
 @IdCivil INT,
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
		
	UPDATE DBO.PadronElectoral SET
	Cedula=@Cedula,
	Nombre=@Nombre,
	Apellido1=@Apellido1,
	Apellido2=@Apellido2,
	Edad=@Edad,
	Estado=@Estado

	WHERE IdCivil=@IdCivil


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