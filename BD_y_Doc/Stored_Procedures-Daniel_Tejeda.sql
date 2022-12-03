--USE [dbVentasEsperanza]

---- UspBuscarClientes
CREATE PROCEDURE [dbo].[UspBuscarClientes]
	@nombre varchar(50)
AS
BEGIN
	IF (@nombre='') BEGIN
		SELECT *
		FROM dbo.Cliente
	END
	ELSE BEGIN
		SELECT *
		FROM dbo.Cliente
		WHERE Nombre like '%' + @nombre + '%'
	END
END
GO


---- UspBuscarUsuarios
CREATE PROCEDURE [dbo].[UspBuscarUsuarios]
	@username varchar(50)
AS
BEGIN
	IF (@username='') BEGIN
		SELECT [Id],[DNI],[Nombres],[Apellidos],[NombreUsuario],[Estado],[IdRol],[FechaCreacion],[FechaModificacion]
		FROM dbo.Usuario
	END
	ELSE BEGIN
		SELECT [Id],[DNI],[Nombres],[Apellidos],[NombreUsuario],[Estado],[IdRol],[FechaCreacion],[FechaModificacion]
		FROM dbo.Usuario
		WHERE Nombres like '%' + @username + '%'
	END
END
GO


---- UspListarVentasPendientes
CREATE PROCEDURE [dbo].[UspListarVentasPendientes]
AS
BEGIN
	
	SELECT * from Venta
	where EstadoServicio in (1,2)

END
GO

-- ///////////////////////////
CREATE PROCEDURE [dbo].[UspListarVentasPorCliente]
	@idCliente int
AS
BEGIN
	IF (@idCliente = 0) BEGIN
		SELECT *
		FROM dbo.Venta
	END
	ELSE BEGIN
		SELECT *
		FROM dbo.Venta
		WHERE IdCliente = @idCliente
	END
	
END
GO

CREATE PROCEDURE [dbo].[UspListarVentasPorUsuario]
	@idUsuario int
AS
BEGIN
	IF (@idUsuario = 0) BEGIN
		SELECT *
		FROM dbo.Venta
	END
	ELSE BEGIN
		SELECT *
		FROM dbo.Venta
		WHERE IdUsuario = @idUsuario
	END
	
END
GO

-- ///////////////////////////


---- MANTENIMIENTO DE USUARIOS
CREATE PROCEDURE [dbo].[uspValidarUsuario]
	@email varchar(50),
	@password varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id],[DNI],[Nombres],[Apellidos],[NombreUsuario],[Estado],[IdRol],[FechaCreacion],[FechaModificacion]
	FROM dbo.Usuario
	WHERE NombreUsuario = @email
	--AND [Password] = @password --comparación si el password no se guardara encriptado
	AND PWDCOMPARE(@password,[Contraseña]) = 1
	AND Estado = 1
END
GO

CREATE PROCEDURE [dbo].[uspCrearUsuario]
	@Dni varchar(8),
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Username varchar(100),
	@Password varchar(15),
	@IdRol int,
	@OV_Message_Result varchar(2000) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF NOT EXISTS(SELECT * FROM dbo.Usuario where NombreUsuario = @Username)
	BEGIN
		BEGIN TRAN
			-- Insert statements for procedure here
			INSERT INTO [dbo].[Usuario]([DNI],[Nombres],[Apellidos],[NombreUsuario],[Contraseña],[Estado],[IdRol],[FechaCreacion])
			VALUES(@Dni,@Nombres,@Apellidos,@Username,PWDENCRYPT(@Password),1,@IdRol,GETDATE())
			--Insert into dbo.Usuario(Nombres,Apellidos,Email,[Login],[Password],Rol,TipoUsuario,Estado)
			--values (@Nombres,@Apellidos,@Email,@Login,PWDENCRYPT(@Password),@Rol,@TipoUsuario,1)

			--paso 2 insert
			--paso 3 update
			--paso 4 insert
			--paso 5 insert

		COMMIT TRAN

		SET @OV_Message_Result = '1-OK'

		Select [Id],[DNI],[Nombres],[Apellidos],[NombreUsuario],[Estado],[IdRol],[FechaCreacion],[FechaModificacion]
		From dbo.Usuario
		Where NombreUsuario = @Username
		AND PWDCOMPARE(@Password,[Contraseña]) = 1
	END
	ELSE BEGIN
		SET @OV_Message_Result = '2-El usuario ya existe'
	END
END TRY
BEGIN CATCH
	SET @OV_Message_Result = '3-Error en el procedimiento almacenado: ' + ERROR_PROCEDURE() + ', Mensaje: ' +
							ERROR_MESSAGE() + ' En la linea: ' + convert(varchar(20),ERROR_LINE())

	ROLLBACK
	--PRINT @OV_Message_Result
END CATCH
GO