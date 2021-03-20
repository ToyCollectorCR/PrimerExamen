CREATE PROCEDURE [dbo].[SolicitudObtener]
	@IdSolicitud INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			SO.IdSolicitud,
			SO.IdCivil,
			SO.IdTipoTramite,
			SO.Detalle,
			SO.Estado,
		    PE.IdCivil,
			PE.Nombre,
		    T.IdTipoTramite,
			T.Descripcion
		

	FROM dbo.Solicitud SO	
	 LEFT JOIN dbo.PadronElectoral PE
         ON SO.IdCivil = PE.IdCivil
	 LEFT JOIN dbo.Tramite T
         ON SO.IdTipoTramite = T.IdTipoTramite
	WHERE
	     (@IdSolicitud IS NULL OR IdSolicitud=@IdSolicitud)

END