--Nombre de la BD: SistemaReservacionHotel--

Create database SistemaReservacionHotel;

Use SistemaReservacionHotel;

CREATE TABLE TIPO_HABITACION
( 
	IDTipoHabitacion     int  NOT NULL IDENTITY,
	NombreTipoHabitacion varchar(50)  NOT NULL ,
	CostoTipoHabitacion  int  NOT NULL,
    PRIMARY KEY (IDTipoHabitacion)
);

CREATE TABLE HABITACION(
	IDHabitacion		int NOT NULL IDENTITY,
	PisoHabitacion		varchar(20) NOT NULL,
    IDTipoHabitacion    int NOT NULL,
	PRIMARY KEY (IDHabitacion),
    FOREIGN KEY (IDTipoHabitacion) REFERENCES TIPO_HABITACION (IDTipoHabitacion)
);

CREATE TABLE ROL
( 
	IDRol                int  NOT NULL IDENTITY,
	NombreRol            varchar(20)  NULL,
    PRIMARY KEY (IDRol)
);

CREATE TABLE USUARIO
( 
	IDUsuario            		int NOT NULL IDENTITY,
	PrimerNombre               	varchar(40)  NOT NULL ,
    SegundoNombre               varchar(40)  NULL ,
	PrimerApellido              varchar(40)  NOT NULL ,
    SegundoApellido             varchar(40)  NOT NULL ,
	Username             		varchar(40)  NOT NULL ,
	Contrasena           		varchar(40)  NOT NULL ,
	IDRol                		integer NOT NULL,
    PRIMARY KEY (IDUsuario),
    FOREIGN KEY (IDRol) REFERENCES ROL (IDRol)
);

CREATE TABLE SERVICIO(
	IDServicio int NOT NULL IDENTITY,
	NombreServicio varchar(100) NOT NULL,
	CostoServicio int NOT NULL,
	PRIMARY KEY(IDServicio)
);

CREATE TABLE RESERVACIONES
( 
	IDReservacion        int		NOT NULL IDENTITY,
	FechaInicio          datetime	NOT NULL ,
	CantidadNoches       int  		NOT NULL ,
	NombreCliente        varchar(100)  	NOT NULL ,
	CedulaCliente        int  		NOT NULL ,
    IDHabitacion		 int		NOT NULL ,
	IDUsuario            int  		NULL,
	IDServicio           int  		NULL,
	PRIMARY KEY (IDReservacion),
    FOREIGN KEY (IDHabitacion) REFERENCES HABITACION (IDHabitacion),
    FOREIGN KEY (IDUsuario) REFERENCES USUARIO (IDUsuario),
    FOREIGN KEY (IDServicio) REFERENCES SERVICIO(IDServicio)
);

INSERT INTO ROL(NombreRol)  VALUES ('Administrador');
INSERT INTO ROL(NombreRol)  VALUES ('Estándar');

INSERT INTO USUARIO(PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Username, Contrasena, IDRol)  VALUES ('Administrador', NULL, 'Administrador', 'Administrator', 'admin', '12345', 1);

INSERT INTO TIPO_HABITACION(NombreTipoHabitacion, CostoTipoHabitacion) VALUES('Suite', 100000);
INSERT INTO TIPO_HABITACION(NombreTipoHabitacion, CostoTipoHabitacion) VALUES('Familiar', 50000);
INSERT INTO TIPO_HABITACION(NombreTipoHabitacion, CostoTipoHabitacion) VALUES('Individual', 20000);

INSERT INTO HABITACION(PisoHabitacion,IDTipoHabitacion) VALUES('Primero', 1);
INSERT INTO HABITACION(PisoHabitacion,IDTipoHabitacion) VALUES('Primero', 1);

INSERT INTO SERVICIO(NombreServicio,CostoServicio) VALUES('Todo Incluido', 100000);

INSERT INTO RESERVACIONES(FechaInicio,CantidadNoches,NombreCliente,CedulaCliente,IDHabitacion,IDUsuario,IDServicio) 
VALUES(13/05/2021,4,'Jhon Doe',109500546,1,1,1);

SELECT * FROM TIPO_HABITACION
SELECT * FROM HABITACION
SELECT * FROM ROL
SELECT * FROM USUARIO
SELECT * FROM RESERVACIONES
SELECT * FROM SERVICIO
SELECT * FROM AspNetUsers