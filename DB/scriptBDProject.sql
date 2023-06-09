USE [db_project]
GO
/****** Object:  Table [dbo].[Transporte]    Script Date: 3/05/2023 17:22:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transporte](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Descripcion] [varchar](max) NULL,
	[Latitud] [varchar](500) NULL,
	[Longitud] [varchar](500) NULL,
 CONSTRAINT [PK_Transporte] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicacion]    Script Date: 3/05/2023 17:22:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTransporte] [int] NULL,
	[Ubicacion] [varchar](max) NULL,
	[Descripcion] [varchar](max) NULL,
	[Latitud] [varchar](500) NULL,
	[Longitud] [varchar](500) NULL,
 CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 3/05/2023 17:22:12 ******/
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
SET IDENTITY_INSERT [dbo].[Transporte] ON 

INSERT [dbo].[Transporte] ([Id], [Nombre], [Descripcion], [Latitud], [Longitud]) VALUES (1, N'Paradero Linea 13', N'Paradero Linea 13', N'-17.99426', N'-70.251855')
INSERT [dbo].[Transporte] ([Id], [Nombre], [Descripcion], [Latitud], [Longitud]) VALUES (2, N'Paradero de la Linea 1', N'Paradero de la Linea 1', NULL, NULL)
INSERT [dbo].[Transporte] ([Id], [Nombre], [Descripcion], [Latitud], [Longitud]) VALUES (3, N'Paradero Linea 300', N'Paradero Linea 300', N'-17.99123', N'-70.212342')
SET IDENTITY_INSERT [dbo].[Transporte] OFF
GO
SET IDENTITY_INSERT [dbo].[Ubicacion] ON 

INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1, 1, N'23004, Perú', N'asd', N'-18.0768373', N'-70.2539698')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (2, 1, N'23004, Perú', NULL, N'-18.0332785', N'-70.2518078')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (3, 1, N'Tacna 23001, Perú', NULL, N'-18.0025415', N'-70.2444134')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (4, 1, N'Tacna 23001, Perú', NULL, N'-18.00213335623262', N'-70.2438555005249')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (5, 1, N'Tacna 23001, Perú', NULL, N'-17.995358031693403', N'-70.25123693973389')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (6, 1, N'15122, Perú', NULL, N'-11.8335016', N'-77.1133808')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (7, 1, N'Tacna 23002, Perú', NULL, N'-17.99397428604554', N'-70.25138293121337')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1005, 1, N'23004, Perú', NULL, N'-17.99426', N'-70.251855')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1006, 1, N'Tacna 23001, Perú	', NULL, N'-17.99426', N'-70.251855')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1007, 1, N'15122, Perú	', NULL, N'-17.99426', N'-70.251855')
SET IDENTITY_INSERT [dbo].[Ubicacion] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (1, 3, N'ADMINISTRADOR', N'ADMIN', N'123', 1)
INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (2, 2, N'Manuel Murguia', N'Manuel@gmail.com', N'123', 1)
INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (3, 1, N'Oscar Ticona', N'Oscar@gmail.com', N'123', 1)
INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (4, 2, N'Flor Rodriguez', N'Flor@gmail.com', N'123', 1)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
ALTER TABLE [dbo].[Ubicacion]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Transporte] FOREIGN KEY([IdTransporte])
REFERENCES [dbo].[Transporte] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ubicacion] CHECK CONSTRAINT [FK_Ubicacion_Transporte]
GO
