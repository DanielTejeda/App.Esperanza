USE [dbVentasEsperanza]
GO

/****** 
+++++
		CREACION DE TABLAS
+++++
******/



/****** Object:  Table [dbo].[Agencia]    Script Date: 1/11/2022 17:13:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Agencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [nvarchar](100) NULL,
	[Celular] [nvarchar](9) NOT NULL,
	[Departamento] [nvarchar](20) NULL,
	[Estado] [bit] NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Agencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Servicio]    Script Date: 1/11/2022 17:18:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Servicio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Descripcion] [nvarchar](1000) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Rol]    Script Date: 1/11/2022 17:20:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 1/11/2022 17:36:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](10) NOT NULL,
	[DNI] [nvarchar](8) NULL,
	[RUC] [nvarchar](11) NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Celular] [nvarchar](9) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 1/11/2022 17:47:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [nvarchar](8) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[NombreUsuario] [nvarchar](25) NOT NULL,
	[Contraseña] [varbinary](250) NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdRol] [int] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Venta]    Script Date: 1/11/2022 17:56:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Venta](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdServicio] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdAgencia] [int] NOT NULL,
	[Detalle] [nvarchar](1000) NOT NULL,
	[Partida] [nvarchar](20) NOT NULL,
	[Llegada] [nvarchar](20) NOT NULL,
	[Costo] [decimal](18, 2) NOT NULL,
	[CostoAdicional] [decimal](18, 2) NULL,
	[DetalleCostoAdicional] [nvarchar](1000) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[EstadoServicio] [int] NOT NULL,
	[FechaEntrega] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Log]    Script Date: 28/03/2022 19:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](4000) NOT NULL,
	[Exception] [varchar](2000) NULL
) ON [PRIMARY]
GO

/****** 
+++++
		INSERTS
+++++
******/
SET IDENTITY_INSERT [dbo].[Agencia] ON 

INSERT INTO [dbo].[Agencia]([Id],[Direccion],[Celular],[Departamento],[Estado],[Nombre])VALUES(1,'Av. Tupac Amaru 7612 - Comas','992470132','Lima',1,'Comas')
INSERT INTO [dbo].[Agencia]([Id],[Direccion],[Celular],[Departamento],[Estado],[Nombre])VALUES(2,'Av. Alfredo Mendiola 5633 - Los Olivos','967487277','Lima',1,'Los Olivos')
INSERT INTO [dbo].[Agencia]([Id],[Direccion],[Celular],[Departamento],[Estado],[Nombre])VALUES(3,'Av. Los Sauces 136 - Ate','984655321','Lima',1,'Ate')
INSERT INTO [dbo].[Agencia]([Id],[Direccion],[Celular],[Departamento],[Estado],[Nombre])VALUES(4,'Av. Arica 263 - Huancayo','912954857','Junin',1,'Huancayo')
INSERT INTO [dbo].[Agencia]([Id],[Direccion],[Celular],[Departamento],[Estado],[Nombre])VALUES(5,'Av. Francisco Pizarro 148 - Jauja','982298750','Junin',1,'Jauja')

SET IDENTITY_INSERT [dbo].[Agencia] OFF
GO

SET IDENTITY_INSERT [dbo].[Servicio] ON 

INSERT INTO [dbo].[Servicio]([Id],[Nombre],[Descripcion],[Estado])VALUES(1,'Mudanza','Mudanzas de hogar, oficina, de empresas o almacenes',1)
INSERT INTO [dbo].[Servicio]([Id],[Nombre],[Descripcion],[Estado])VALUES(2,'Encomiendas','Traslado de encomiendas, sobres y paquetes',1)

SET IDENTITY_INSERT [dbo].[Servicio] OFF
GO

SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT INTO [dbo].[Cliente]([Id],[Tipo],[DNI],[RUC],[Nombre],[Celular],[Estado])VALUES(1,'Persona','52654390','','Cliente de prueba 1','917003441',1)

SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO

SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT INTO [dbo].[Rol]([Id],[Nombre],[Estado])VALUES(1,'Administrador',1)
INSERT INTO [dbo].[Rol]([Id],[Nombre],[Estado])VALUES(2,'Asesor de Ventas',1)
INSERT INTO [dbo].[Rol]([Id],[Nombre],[Estado])VALUES(3,'Operario',1)

SET IDENTITY_INSERT [dbo].[Rol] OFF
GO

SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT INTO [dbo].[Usuario]([Id],[DNI],[Nombres],[Apellidos],[NombreUsuario],[Contraseña],[Estado],[IdRol])
VALUES(1,'73457689','Daniel Salomon','Tejeda Aguilar','DTEJEDA',PWDENCRYPT(12345678),1,1)

INSERT INTO [dbo].[Usuario]([Id],[DNI],[Nombres],[Apellidos],[NombreUsuario],[Contraseña],[Estado],[IdRol])
VALUES(2,'17172611','Bryan','Tejeda Vasquez','BTEJEDA',PWDENCRYPT(12345678),1,2)

INSERT INTO [dbo].[Usuario]([Id],[DNI],[Nombres],[Apellidos],[NombreUsuario],[Contraseña],[Estado],[IdRol])
VALUES(3,'64034348','Julia','Salgado Perez','JSALGADO',PWDENCRYPT(12345678),1,2)

INSERT INTO [dbo].[Usuario]([Id],[DNI],[Nombres],[Apellidos],[NombreUsuario],[Contraseña],[Estado],[IdRol])
VALUES(4,'72219681','Juan Carlos','Garagati Rojas','JGARAGATI',PWDENCRYPT(12345678),1,3)

INSERT INTO [dbo].[Usuario]([Id],[DNI],[Nombres],[Apellidos],[NombreUsuario],[Contraseña],[Estado],[IdRol])
VALUES(5,'12345678','Test_User_1','','USER1',PWDENCRYPT(12345678),1,1)

SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO

/****** 
+++++
		DEFINIR FK's
+++++
******/
/* para la tabla USUARIO */
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol]([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO

/* para la tabla VENTA */
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio]([Id])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Servicio]
GO

ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario]([Id])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Usuario]
GO

ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente]([Id])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO

ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Agencia] FOREIGN KEY([IdAgencia])
REFERENCES [dbo].[Agencia]([Id])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Agencia]
GO
