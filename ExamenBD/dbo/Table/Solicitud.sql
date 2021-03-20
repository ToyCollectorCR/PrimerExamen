CREATE TABLE [dbo].[Solicitud]
(
	IdSolicitud INT NOT NULL IDENTITY(1,1) 
		CONSTRAINT PK_Solicitud PRIMARY KEY CLUSTERED(IdSolicitud)
	, IdCivil INT NOT NULL
		CONSTRAINT FK_Solicitud_Civil FOREIGN KEY (IdCivil) REFERENCES dbo.PadronElectoral(IdCivil)
	, IdTipoTramite INT NOT NULL
		CONSTRAINT FK_Solicitud_TipoTramite FOREIGN KEY (IdTipoTramite) REFERENCES dbo.Tramite(IdTipoTramite)
	, Detalle VARCHAR(1000) NOT NULL
	, Estado BIT NOT NULL
		CONSTRAINT DF_Solicitud_Estado DEFAULT(0)
)WITH (DATA_COMPRESSION = PAGE)
