CREATE PROCEDURE [dbo].[PadronElectoralObtener]
	@IdCivil INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			IdCivil,
			Cedula,
			Nombre,
			Apellido1,
			Apellido2,
			Edad,
			Estado

	FROM dbo.PadronElectoral
	WHERE
	     (@IdCivil IS NULL OR IdCivil=@IdCivil)

END