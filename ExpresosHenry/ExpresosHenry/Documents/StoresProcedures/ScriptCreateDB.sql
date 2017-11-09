CREATE DATABASE ExpresosHenry;

GO
USE ExpresosHenry;

GO

CREATE TABLE  usuario(
    usuCodigo INT NOT NULL,
    usuIdentificacion VARCHAR(30),
    usuTipoIdentificacion VARCHAR(30),
    usuNombres VARCHAR(50),
    usuApellido VARCHAR(50),
    usuFechaNaci DATE,
    usuSexo VARCHAR(6),
    usuEstatura VARCHAR(50),
    usuNacionalidad VARCHAR(50),
    usuFechaRegistro DATETIME,   
    CONSTRAINT pk_usuario PRIMARY KEY (usuCodigo));

GO

    CREATE TABLE  cliente(
    cliCodigo INT NOT NULL,
    cliIdentificacion VARCHAR(30),
    cliTipoIdentificacion VARCHAR(30),
    cliNombres VARCHAR(50),
    cliApellido VARCHAR(50),
    cliFechaNaci DATE,
    cliSexo VARCHAR(6),
    cliEstatura VARCHAR(50),
    cliNacionalidad VARCHAR(50),   
    cliFechaRegistro DATETIME,
    CONSTRAINT pk_cliente PRIMARY KEY (cliCodigo));
GO



CREATE TABLE  vehiculo(
    vehCodigo INT NOT NULL,
    vehPlaca VARCHAR(30),
    vehColor VARCHAR(30),
    vehCantRuedas INT,
    vehCantPasajeros INT,
    vehModelo INT,
    vehAnios INT,
    CONSTRAINT pk_vehiculo PRIMARY KEY (vehCodigo));

GO

CREATE TABLE  ticket(
    ticCodigo INT NOT NULL,
    ticFechaVenta DATETIME,
    ticFechaIni DATETIME,
    ticFechaFin DATETIME,
    cliCodigo INT NOT NULL,
    ticTrayect DECIMAL,
    ticLugarSalida VARCHAR(50),
    ticLugarLlegada VARCHAR(50),
    vehCodigo INT NOT NULL,
    usuCodigo INT NOT NULL,    
    ticEstado VARCHAR(50),
    ticCosto INT,
    ticImpuesto INT,
    CONSTRAINT pk_ticket PRIMARY KEY (ticCodigo),
    CONSTRAINT fk_usuario FOREIGN KEY (usuCodigo) REFERENCES usuario(usuCodigo),
    CONSTRAINT fk_cliente FOREIGN KEY (cliCodigo) REFERENCES cliente(cliCodigo),
    CONSTRAINT fk_vehiculo FOREIGN KEY (vehCodigo) REFERENCES vehiculo(vehCodigo));

GO