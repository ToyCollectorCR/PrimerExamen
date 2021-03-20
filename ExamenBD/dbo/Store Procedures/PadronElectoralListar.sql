CREATE PROCEDURE [dbo].[PadronElectoralListar]
	

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
	     Estado=1
		 order by Nombre

END