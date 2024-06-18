USE [master]
GO

CREATE DATABASE [Amasula_BD]
GO

USE [Amasula_BD]
GO


CREATE TABLE [dbo].[tCarrito](
	[IdCarrito] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
 CONSTRAINT [PK_tCarrito] PRIMARY KEY CLUSTERED 
(
	[IdCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tCategoria](
	[IdCategoria] [smallint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tDetalleFactura](
	[IdDetalle] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[IdCarrito] [bigint] NOT NULL,
	[CodigoFactura] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_tFactura] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tProducto](
	[IdProducto] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Imagen] [varchar](500) NOT NULL,
	[IdCategoria] [smallint] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_tServicio] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tRol](
	[IdRol] [smallint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tRol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tUsuario](
	[IdUsuario] [bigint] IDENTITY(1,1) NOT NULL,
	[Correo] [varchar](200) NOT NULL,
	[Contrasenna] [varchar](200) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[IdRol] [smallint] NOT NULL,
	[Estado] [bit] NOT NULL,
	[EsTemporal] [bit] NOT NULL,
 CONSTRAINT [PK_tUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[tCarrito] ON 
GO
INSERT [dbo].[tCarrito] ([IdCarrito], [IdUsuario], [IdProducto], [Cantidad], [Fecha]) VALUES (14, 2, 1, 1, CAST(N'2024-03-28' AS Date))
GO
INSERT [dbo].[tCarrito] ([IdCarrito], [IdUsuario], [IdProducto], [Cantidad], [Fecha]) VALUES (15, 2, 2, 1, CAST(N'2024-03-28' AS Date))
GO
INSERT [dbo].[tCarrito] ([IdCarrito], [IdUsuario], [IdProducto], [Cantidad], [Fecha]) VALUES (16, 2, 43, 1, CAST(N'2024-03-28' AS Date))
GO
INSERT [dbo].[tCarrito] ([IdCarrito], [IdUsuario], [IdProducto], [Cantidad], [Fecha]) VALUES (17, 2, 41, 1, CAST(N'2024-03-28' AS Date))
GO
INSERT [dbo].[tCarrito] ([IdCarrito], [IdUsuario], [IdProducto], [Cantidad], [Fecha]) VALUES (18, 2, 41, 1, CAST(N'2024-03-28' AS Date))
GO
INSERT [dbo].[tCarrito] ([IdCarrito], [IdUsuario], [IdProducto], [Cantidad], [Fecha]) VALUES (19, 2, 6, 1, CAST(N'2024-03-28' AS Date))
GO
INSERT [dbo].[tCarrito] ([IdCarrito], [IdUsuario], [IdProducto], [Cantidad], [Fecha]) VALUES (20, 2, 7, 1, CAST(N'2024-03-28' AS Date))
GO

SET IDENTITY_INSERT [dbo].[tCarrito] OFF
GO
SET IDENTITY_INSERT [dbo].[tCategoria] ON 
GO

INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (1, N'Mermelada')
GO
INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (2, N'conservas en vinagre')
GO
INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (3, N'Sales')
GO
INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (4, N'Salsas')
GO
INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (5, N'Aceites')
GO
INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (6, N'Vinos')
GO
INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (7, N'Chilera')
GO

SET IDENTITY_INSERT [dbo].[tCategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[tProducto] ON 
GO

INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (1, N'Fresa chía', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (2, N'Ayote con naranja', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (3, N'Fresa chía', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (4, N'Frutas', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (5, N'Frutos Rojos', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (6, N'Guayaba', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (7, N'Mango Maracuyá', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (8, N'Mango uchuvas', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (9, N'Mora', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (10, N'Papaya maracuyá', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (11, N'piña', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (12, N'Piña coco', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 1, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (20, N'Cebollitas Agridulces', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 2, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (21, N'Encurtido verduras', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 2, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (22, N'Jalapeña pequeña', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 2, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (23, N'Jalapeña grande', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 2, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (24, N'Repollo grande', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 2, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (25, N'Verduritas pequeña', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 2, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (26, N'Verduritas grande', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 2, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (31, N'Hierbas', CAST(3000.00 AS Decimal(18, 2)), N'PRUEBA', 3, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (32, N'Ajo', CAST(3000.00 AS Decimal(18, 2)), N'PRUEBA', 3, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (33, N'Codimento Narural', CAST(3000.00 AS Decimal(18, 2)), N'PRUEBA', 3, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (34, N'Picante', CAST(3000.00 AS Decimal(18, 2)), N'PRUEBA', 3, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (35, N'Pimienta Negra', CAST(3000.00 AS Decimal(18, 2)), N'PRUEBA', 3, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (36, N'Himalaya Simple', CAST(3000.00 AS Decimal(18, 2)), N'PRUEBA', 3, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (37, N'Sales en DoyPack', CAST(3000.00 AS Decimal(18, 2)), N'PRUEBA', 3, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (41, N'BBQ 165 ml', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 4, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (42, N'BBQ 200 ml', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 4, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (43, N'Carolina Reaper 65 ml', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 4, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (44, N'Carolina Reaper 165 ml', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 4, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (45, N'Carolina Reaper 200 ml', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 4, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (46, N'Picante 200 ml', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 4, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (51, N'Aceite de ajo', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 5, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (52, N'Aceite de chile dulce', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 5, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (53, N'Aceite Carolina Reaper', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 5, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (54, N'Aceite Chile Arbol', CAST(2500.00 AS Decimal(18, 2)), N'PRUEBA', 5, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (61, N'Fresa', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 6, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (62, N'Jamaica cúrcuma', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 6, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (63, N'Jamaica frutos y bayas', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 6, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (64, N'Jamaica Lúpulo', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 6, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (65, N'Jamaica Te verde', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 6, 1)
GO
INSERT [dbo].[tProducto] ([IdProducto], [Nombre], [Precio], [Imagen], [IdCategoria], [Estado]) VALUES (66, N'Jengibre Maracuyá', CAST(2000.00 AS Decimal(18, 2)), N'PRUEBA', 6, 1)
GO

SET IDENTITY_INSERT [dbo].[tProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[tRol] ON 
GO
INSERT [dbo].[tRol] ([IdRol], [Nombre]) VALUES (1, N'Cliente')
GO
INSERT [dbo].[tRol] ([IdRol], [Nombre]) VALUES (2, N'Administrador')
GO
SET IDENTITY_INSERT [dbo].[tRol] OFF
GO
SET IDENTITY_INSERT [dbo].[tUsuario] ON 
GO
INSERT [dbo].[tUsuario] ([IdUsuario], [Correo], [Contrasenna], [Nombre], [IdRol], [Estado], [EsTemporal]) VALUES (1, N'cvasquez10821@ufide.ac.cr', N'mzhhEyLuYke4Q8wSs8gHuA==', N'Claudio Vasquez', 1, 1, 0)
GO
INSERT [dbo].[tUsuario] ([IdUsuario], [Correo], [Contrasenna], [Nombre], [IdRol], [Estado], [EsTemporal]) VALUES (2, N'jimenezsteber@gmail.com', N'HUrfKH3T+gOKifjwRh/l9w==', N'Steber', 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[tUsuario] OFF
GO
SET ANSI_PADDING ON
GO


ALTER TABLE [dbo].[tUsuario] ADD  CONSTRAINT [UK_Correo] UNIQUE NONCLUSTERED 
(
	[Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tDetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_tFactura_tCarrito] FOREIGN KEY([IdCarrito])
REFERENCES [dbo].[tCarrito] ([IdCarrito])
GO
ALTER TABLE [dbo].[tDetalleFactura] CHECK CONSTRAINT [FK_tFactura_tCarrito]
GO
ALTER TABLE [dbo].[tDetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_tFactura_tProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[tProducto] ([IdProducto])
GO
ALTER TABLE [dbo].[tDetalleFactura] CHECK CONSTRAINT [FK_tFactura_tProducto]
GO
ALTER TABLE [dbo].[tProducto]  WITH CHECK ADD  CONSTRAINT [FK_tProducto_tCategoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[tCategoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[tProducto] CHECK CONSTRAINT [FK_tProducto_tCategoria]
GO
ALTER TABLE [dbo].[tUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tUsuario_tRol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[tRol] ([IdRol])
GO
ALTER TABLE [dbo].[tUsuario] CHECK CONSTRAINT [FK_tUsuario_tRol]
GO

CREATE PROCEDURE [dbo].[AgregarCarrito]
    @IdProducto bigint,
    @IdUsuario bigint,
    @Cantidad int,
    @Fecha date
AS
BEGIN
    INSERT INTO tCarrito (IdUsuario, IdProducto, Cantidad, Fecha)
    VALUES (@IdUsuario, @IdProducto, @Cantidad, @Fecha)
END
GO


CREATE PROCEDURE [dbo].[CambiarContrasenna]
	@Correo					VARCHAR(200),
	@Contrasenna			VARCHAR(200),
	@ContrasennaTemporal	VARCHAR(200),
	@EsTemporal				BIT
AS
BEGIN

	DECLARE @Consecutivo BIGINT
	
	SELECT  @Consecutivo = IdUsuario
	FROM	tUsuario
	WHERE	Correo = @Correo
		AND Contrasenna = @ContrasennaTemporal
		AND Estado = 1

	IF @Consecutivo IS NOT NULL
	BEGIN
		UPDATE tUsuario
		SET Contrasenna = @Contrasenna,
			EsTemporal = @EsTemporal
		WHERE Correo = @Correo
	END

	SELECT	IdUsuario,Correo,U.Nombre 'NombreUsuario',U.IdRol,R.Nombre 'NombreRol',Estado,EsTemporal
	  FROM	tUsuario U
	  INNER JOIN tRol R ON U.IdRol = R.IdRol
	  WHERE	Correo = @Correo
		AND Estado = 1

END
GO


CREATE PROCEDURE [dbo].[ConsultarCarrito]
    @IdUsuario bigint
AS
BEGIN
    SELECT C.IdCarrito,C.IdUsuario, C.IdProducto, C.Cantidad, C.Fecha,D.Nombre as 'NombreProducto',D.Precio as 'Precio'
    FROM tCarrito AS C
	INNER JOIN tProducto AS D ON C.IdProducto = D.IdProducto
    WHERE C.IdUsuario = @IdUsuario;
END
GO

CREATE PROCEDURE [dbo].[ConsultarCategorias]
    @MostrarTodos BIT
AS
BEGIN
    IF @MostrarTodos = 1
    BEGIN
        SELECT IdCategoria, Nombre
        FROM tCategoria;
    END
    ELSE
    BEGIN
        SELECT IdCategoria, Nombre
        FROM tCategoria;
    END
END
GO


CREATE PROCEDURE [dbo].[ConsultarProducto]
	@MostrarTodos BIT
AS
BEGIN

	IF(@MostrarTodos = 1)
	BEGIN
		SELECT	IdProducto,Nombre,Precio,Imagen,IdCategoria,Estado
		FROM	dbo.tProducto
	END
	ELSE
	BEGIN
		SELECT	IdProducto,Nombre,Precio,Imagen,IdCategoria,Estado
		FROM	dbo.tProducto
		WHERE	Estado = 1
	END
END
GO


CREATE PROCEDURE [dbo].[ConsultarProductosCat]
	@IdCategoria smallint
AS
BEGIN
		SELECT	C.IdProducto,C.Nombre,C.Precio,C.Imagen,C.Estado,U.Nombre AS 'NombreCategoria'
		FROM	tProducto AS C
		INNER JOIN tCategoria AS U ON C.IdCategoria = U.IdCategoria
		WHERE	C.IdCategoria = @IdCategoria
END

GO



CREATE PROCEDURE [dbo].[IniciarSesion]
	@Correo			VARCHAR(200),
    @Contrasenna	VARCHAR(200)
AS
BEGIN
	
	SELECT	IdUsuario,Correo,U.Nombre 'NombreUsuario',U.IdRol,R.Nombre 'NombreRol',Estado,EsTemporal
	--,U.IdCategoria,C.Nombre 'NombreCategoria'
	  FROM	tUsuario U
	  INNER JOIN tRol R ON U.IdRol = R.IdRol
	  --INNER JOIN tCategoria C ON u.IdCategoria = C.IdCategoria
	  WHERE	Correo = @Correo
		AND Contrasenna = @Contrasenna
		AND Estado = 1

END
GO



CREATE PROCEDURE [dbo].[RecuperarAcceso]
	@Correo			VARCHAR(200),
	@Contrasenna	VARCHAR(200),
	@EsTemporal		BIT
AS
BEGIN

	DECLARE @Consecutivo BIGINT
	
	SELECT  @Consecutivo = IdUsuario
	FROM	tUsuario
	WHERE	Correo = @Correo
		AND Estado = 1

	IF @Consecutivo IS NOT NULL
	BEGIN
		UPDATE tUsuario
		SET Contrasenna = @Contrasenna,
			EsTemporal = @EsTemporal
		WHERE Correo = @Correo
	END

	SELECT	IdUsuario,Correo,U.Nombre 'NombreUsuario',U.IdRol,R.Nombre 'NombreRol',Estado,EsTemporal
	  FROM	tUsuario U
	  INNER JOIN tRol R ON U.IdRol = R.IdRol
	  WHERE	Correo = @Correo
		AND Estado = 1

END
GO


CREATE PROCEDURE [dbo].[RegistrarServicio]
	@Nombre	varchar(200),
	@Precio decimal(18,2),
	@Imagen varchar(500),
	@IdCategoria varchar(500)
AS
BEGIN
	
	IF NOT EXISTS(SELECT 1 FROM tProducto WHERE Nombre = @Nombre)
	BEGIN

		INSERT INTO dbo.tProducto(Nombre,Precio,Imagen,IdCategoria,Estado)
		VALUES (@Nombre,@Precio,@Imagen,@IdCategoria,1)

	END

END
GO


CREATE PROCEDURE [dbo].[RegistrarUsuario]
	@Correo			VARCHAR(200),
    @Contrasenna	VARCHAR(200),
    @NombreUsuario	VARCHAR(200)
AS
BEGIN

	IF NOT EXISTS(SELECT 1 FROM tUsuario WHERE Correo = @Correo)
	BEGIN

		INSERT INTO dbo.tUsuario(Correo,Contrasenna,Nombre,IdRol,Estado,EsTemporal)
		VALUES (@Correo,@Contrasenna,@NombreUsuario,1,1,0)

	END

END
GO

USE [master]
GO

ALTER DATABASE [Amasula_BD] SET  READ_WRITE 
GO
