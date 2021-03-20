CREATE PROCEDURE [dbo].[TipoTramiteObtener]
	@IdTipoTramite INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
		IdTipoTramite,
		Descripcion,
		Estado

	FROM dbo.Tramite
	WHERE
	     (@IdTipoTramite IS NULL OR IdTipoTramite=@IdTipoTramite)

END