IF NOT EXISTS(SELECT 1
			  FROM   SYS.DATABASES
			  WHERE  name = 'checador')
BEGIN
	CREATE DATABASE checador;
END;

USE checador;

DROP TABLE IF EXISTS dbo.registros;
DROP TABLE IF EXISTS dbo.usuarios;
DROP TABLE IF EXISTS dbo.cuentas;
DROP VIEW  IF EXISTS dbo.vwBitacora;
DROP PROCEDURE IF EXISTS dbo.bdInsertUsr;
DROP PROCEDURE IF EXISTS dbo.bdinsertReg;
DROP PROCEDURE IF EXISTS bdConsulta;
DROP PROCEDURE IF EXISTS bdExistUsr;
DROP PROCEDURE IF EXISTS bdNextFolio;
DROP PROCEDURE IF EXISTS bdDeleteUsr;
DROP PROCEDURE IF EXISTS bdGetUsr;
DROP PROCEDURE IF EXISTS bdUpdateUsr;
DROP PROCEDURE IF EXISTS bdLogin;
GO
CREATE TABLE cuentas(
	id       INT PRIMARY KEY IDENTITY(1,1),
	alias   VARCHAR(300),
	password VARCHAR(500)
);
INSERT INTO cuentas(alias, password) VALUES('JJNAVARRETE','123');
GO
CREATE TABLE usuarios(
	id       INT PRIMARY KEY IDENTITY(1,1),
	folio    VARCHAR(50) ,
	nombre   VARCHAR(300),
	apellido VARCHAR(300)
);

CREATE UNIQUE NONCLUSTERED INDEX uq_usuarios_folio
ON    dbo.usuarios(folio)
WHERE folio IS NOT NULL;

CREATE TABLE registros(
	id        INT PRIMARY KEY IDENTITY(1,1),
	fecha     DATE,
	hora      VARCHAR(20),
	usr_id INT NOT NULL,
	FOREIGN KEY(usr_id) REFERENCES usuarios(id)
);
GO
CREATE VIEW vwBitacora AS
	SELECT a.folio, UPPER(a.nombre + ' ' +a.apellido) as nombre, 
		   FORMAT(b.fecha,'dd/MM/yyyy') as fecha, b.hora
	FROM   registros b, usuarios a
	WHERE  b.usr_id = a.id;

GO
CREATE TRIGGER trgUsuarios 
ON usuarios 
AFTER INSERT
AS
BEGIN
	UPDATE usuarios
	SET    folio = 'U33'+CONVERT(VARCHAR(50),inserted.id)
	FROM   inserted
	WHERE  usuarios.id    = inserted.id;
END;
GO
CREATE PROCEDURE  bdLogin(@usr VARCHAR(50), @pass VARCHAR(50)) AS
BEGIN
	SELECT 1 comodin
	FROM   cuentas
	WHERE  alias = @usr
	AND    password = @pass;
END;
GO
CREATE PROCEDURE  bdGetUsr(@folio VARCHAR(50)) AS
BEGIN
	SELECT *
	FROM   usuarios
	WHERE  folio = @folio;
END;
GO
CREATE PROCEDURE  bdUpdateUsr(@folio   VARCHAR(50), @nombre VARCHAR(50),
						     @apellido VARCHAR(50))
AS
BEGIN
	UPDATE usuarios
	SET    nombre	= @nombre,
		   apellido = @apellido
	WHERE  folio	= @folio;
END;
GO
CREATE PROCEDURE bdDeleteUsr(@folio VARCHAR(50))
AS
BEGIN
	DELETE 
	FROM
	registros WHERE usr_id = (SELECT id 
							  FROM usuarios WHERE folio = @folio);
	DELETE 
	FROM
	usuarios WHERE folio = @folio;
END;
GO
CREATE PROCEDURE bdConsulta(@folio VARCHAR(50), @nombre VARCHAR(600),
							@fecha VARCHAR(20), @fecha2   VARCHAR(20))
AS
BEGIN
	IF @folio = '' 
	BEGIN
		SET @folio = null;
	END

	IF @nombre = '' 
	BEGIN
		SET @nombre = null;
	END

	IF @fecha = '' 
	BEGIN
		SET @fecha = null;
	END

	IF @fecha2 = '' 
	BEGIN
		SET @fecha2 = null;
	END

	SET NOCOUNT OFF;

	SELECT *
	FROM   vwbitacora vw
	WHERE  0 <> 1	
	AND    LOWER(vw.folio)  = LOWER(COALESCE(@folio  , vw.folio))
	AND    LOWER(vw.nombre) LIKE LOWER(COALESCE(@nombre , vw.nombre))+'%'
	AND    vw.fecha         BETWEEN FORMAT(CONVERT(date,COALESCE(@fecha,vw.fecha)),'dd/MM/yyyy') 
						    AND FORMAT(CONVERT(date,COALESCE(@fecha2,vw.fecha)),'dd/MM/yyyy')
	
END;
GO
CREATE PROCEDURE bdNextFolio AS
BEGIN
	SELECT 'U33' + CONVERT(VARCHAR,MAX(ID) + 1) next_folio
	FROM   usuarios
END;
GO

CREATE PROCEDURE bdInsertUsr(@nombre VARCHAR(300), @apellido VARCHAR(300)) AS
BEGIN
	INSERT INTO USUARIOS(nombre, apellido) VALUES(@nombre, @apellido);
END
GO
CREATE PROCEDURE bdInsertReg(@folio VARCHAR(50)) AS
BEGIN
	INSERT INTO registros  SELECT FORMAT(GETDATE(),'dd/MM/yyyy')  fecha,
								  FORMAT(GETDATE(),'hh:mm:ss tt', 'en-US') hora ,
								  u.id
						   FROM   usuarios u
						   WHERE  u.folio = @folio;
END
GO
CREATE PROCEDURE bdExistUsr(@folio VARCHAR(300)) AS
BEGIN
	SELECT 1
	FROM   dbo.usuarios
	WHERE  folio = @folio;
END
GO
EXEC bdInsertUsr 'JESUS JOSE','NAVARRETE BACA';
EXEC bdInsertUsr 'ELADIO'    ,'MARISCAL QUINTANA';
EXEC bdInsertUsr 'DOMITILIO' ,'PALMA SAENZ';
EXEC bdInsertUsr 'VICENTE'   ,'CARO';
EXEC bdInsertUsr 'JORGE'     ,'MONTES LIGHTBOURN';
EXEC bdInsertUsr 'EDGAR'     ,'BECKMAN SALAS';
GO

DECLARE @cc    INT = 0,
		@folio VARCHAR(50);

DECLARE curUsrs CURSOR FOR
				SELECT folio
				FROM   usuarios;	
BEGIN
	

	BEGIN
		OPEN curUsrs;
		FETCH NEXT FROM curUsrs INTO @folio;

		WHILE @@FETCH_STATUS = 0 	 
		BEGIN		
		    WHILE @cc < 500
				BEGIN
					EXEC bdInsertReg @folio;				
					SET @cc = @cc + 1;
				END;
			SET @CC = 0;
			FETCH NEXT FROM curUsrs INTO @folio;
		END;

		CLOSE curUsrs;

		DEALLOCATE curUsrs;		
	END;

END;





