CREATE PROCEDURE [dbo].[TipoTramiteListar]
	AS BEGIN
	SET NOCOUNT ON

	SELECT
        
		IdTipoTramite,
		Descripcion,
	    Estado


	FROM dbo.Tramite
	WHERE
	     Estado=1
		 order by Descripcion

END