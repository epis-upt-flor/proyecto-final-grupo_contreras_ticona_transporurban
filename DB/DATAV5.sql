USE [db_project]
GO
/****** Object:  Table [dbo].[Notificacion]    Script Date: 17/05/2023 13:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Descripcion] [varchar](max) NULL,
	[Direccion] [varchar](max) NULL,
	[Latitud] [varchar](500) NULL,
	[Longitud] [varchar](500) NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Notificacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transporte]    Script Date: 17/05/2023 13:31:43 ******/
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
/****** Object:  Table [dbo].[Ubicacion]    Script Date: 17/05/2023 13:31:43 ******/
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
/****** Object:  Table [dbo].[usuario]    Script Date: 17/05/2023 13:31:43 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 17/05/2023 13:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idTipoUsuario] [varchar](100) NULL,
	[usuario] [varchar](100) NULL,
	[password] [varchar](100) NULL,
	[estado] [tinyint] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Transporte] ON 

INSERT [dbo].[Transporte] ([Id], [Nombre], [Descripcion], [Latitud], [Longitud]) VALUES (1, N'Paradero Linea 11 Tacna, Perú', N'Paradero Linea 11 Tacna, Perú', N'-18.0759509', N'-70.24771559999999')
INSERT [dbo].[Transporte] ([Id], [Nombre], [Descripcion], [Latitud], [Longitud]) VALUES (2, N'Paradero de la Linea 1', N'Paradero de la Linea 1', NULL, NULL)
INSERT [dbo].[Transporte] ([Id], [Nombre], [Descripcion], [Latitud], [Longitud]) VALUES (3, N'Paradero Linea 300', N'Paradero Linea 300', N'-17.99123', N'-70.212342')
SET IDENTITY_INSERT [dbo].[Transporte] OFF
GO
SET IDENTITY_INSERT [dbo].[Ubicacion] ON 

INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1008, 1, N'23004, Perú', NULL, N'-18.072564691237044', N'-70.2512668447357')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1009, 1, N'23004, Perú', NULL, N'-18.06843383609948', N'-70.25168526934202')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1010, 1, N'23004, Perú', NULL, N'-18.065001582556704', N'-70.2520071344238')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1011, 1, N'23004, Perú', NULL, N'-18.064634383555468', N'-70.25162626074369')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1012, 1, N'23004, Perú', NULL, N'-18.064244233775614', N'-70.25136876867826')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1013, 1, N'23004, Perú', NULL, N'-18.0640835836144', N'-70.25038708017884')
INSERT [dbo].[Ubicacion] ([Id], [IdTransporte], [Ubicacion], [Descripcion], [Latitud], [Longitud]) VALUES (1014, 1, N'23004, Perú', NULL, N'-18.063981583435798', N'-70.24950731562195')
SET IDENTITY_INSERT [dbo].[Ubicacion] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (1, 3, N'ADMINISTRADOR', N'ADMIN', N'123', 1)
INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (2, 2, N'Manuel Murguia', N'Manuel@gmail.com', N'123', 1)
INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (3, 1, N'Oscar Ticona', N'Oscar@gmail.com', N'123', 1)
INSERT [dbo].[usuario] ([id], [idTipoUsuario], [nombreCompleto], [usuario], [password], [estado]) VALUES (4, 2, N'Flor Rodriguez', N'Flor@gmail.com', N'123', 1)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [idTipoUsuario], [usuario], [password], [estado]) VALUES (1, N'3', N'ADMIN', N'123', 1)
INSERT [dbo].[Usuarios] ([Id], [idTipoUsuario], [usuario], [password], [estado]) VALUES (2, N'2', N'Manuel@gmail.com', N'123', 1)
INSERT [dbo].[Usuarios] ([Id], [idTipoUsuario], [usuario], [password], [estado]) VALUES (3, N'2', N'Flor Rodriguez', N'123', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Notificacion]  WITH CHECK ADD  CONSTRAINT [FK_Notificacion_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notificacion] CHECK CONSTRAINT [FK_Notificacion_Usuarios]
GO
ALTER TABLE [dbo].[Ubicacion]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Transporte] FOREIGN KEY([IdTransporte])
REFERENCES [dbo].[Transporte] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ubicacion] CHECK CONSTRAINT [FK_Ubicacion_Transporte]
GO
