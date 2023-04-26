USE [db_project]
GO
/****** Object:  Table [dbo].[derivacion]    Script Date: 10/04/2023 18:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[derivacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idDocumento] [int] NULL,
	[idTipoDerivacion] [int] NULL,
	[fechaDerivacion] [date] NULL,
	[accionRealizar] [varchar](100) NULL,
	[documentoEmitido] [varchar](100) NULL,
	[comentario] [varchar](100) NULL,
	[estadoExpediente] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[documento]    Script Date: 10/04/2023 18:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[documento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[nroExpediente] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[codigoModular] [varchar](100) NULL,
	[motivo] [varchar](100) NULL,
	[observacion] [varchar](100) NULL,
	[fecha] [date] NULL,
	[dni] [varchar](8) NULL,
	[tituloProfesional] [varchar](100) NULL,
	[especialidad] [varchar](100) NULL,
	[establecimiento] [varchar](100) NULL,
	[nivelMagisterial] [varchar](100) NULL,
	[jornadaLaboral] [varchar](100) NULL,
	[regimenPension] [varchar](100) NULL,
	[nroIpss] [varchar](100) NULL,
	[fechaIngreso] [date] NULL,
	[fechaCese] [date] NULL,
	[codigoEscalafon] [varchar](100) NULL,
	[anios] [int] NULL,
	[meses] [int] NULL,
	[dias] [int] NULL,
	[cargo] [varchar](100) NULL,
	[tipoServidor] [varchar](100) NULL,
	[otros] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resolucion]    Script Date: 10/04/2023 18:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resolucion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idDocumento] [int] NULL,
	[codigo] [varchar](100) NULL,
	[fechaAsignacion] [date] NULL,
	[motivo] [varchar](100) NULL,
	[dni] [varchar](11) NULL,
	[tituloProfesional] [varchar](100) NULL,
	[especialidad] [varchar](100) NULL,
	[establecimiento] [varchar](100) NULL,
	[nivelMagisterial] [varchar](100) NULL,
	[jornadaLaboral] [varchar](100) NULL,
	[regimenPension] [varchar](100) NULL,
	[nroIpss] [varchar](100) NULL,
	[fechaIngreso] [date] NULL,
	[fechaCese] [date] NULL,
	[codigoEscalafon] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoderivacion]    Script Date: 10/04/2023 18:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoderivacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[estado] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 10/04/2023 18:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idTipoUsuario] [int] NULL,
	[nombreCompleto] [varchar](100) NULL,
	[usuario] [varchar](100) NULL,
	[password] [varchar](100) NULL,
	[estado] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tipoderivacion] ON 

INSERT [dbo].[tipoderivacion] ([id], [nombre], [estado]) VALUES (1, N'DERIVAR 1', 1)
INSERT [dbo].[tipoderivacion] ([id], [nombre], [estado]) VALUES (2, N'DERIVAR 2', 1)
INSERT [dbo].[tipoderivacion] ([id], [nombre], [estado]) VALUES (3, N'DERIVAR 3', 1)
SET IDENTITY_INSERT [dbo].[tipoderivacion] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (1, 3, N'ADMINISTRADOR', N'ADMIN', N'123', 1)
INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (2, 2, N'Manuel Murguia', N'Manuel@gmail.com', N'123', 1)
INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (3, 1, N'Oscar Ticona', N'Oscar@gmail.com', N'123', 1)
INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (4, 2, N'Flor Rodriguez', N'Flor@gmail.com', N'123', 1)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
