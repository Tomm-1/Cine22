CREATE DATABASE Cine22;
USE Cine22;
CREATE TABLE Genero(
    idGenero TINYINT NOT NULL,
    Genero VARCHAR (45) NOT NULL,
    PRIMARY KEY (IdGenero)
);
CREATE TABLE Pelicula(
    idPelicula TINYINT NOT NULL,
    Nombre VARCHAR (50) NOT NULL,
    Lanzamiento DATE NOT NULL,
    IdGenero TINYINT NOT NULL,
    PRIMARY KEY (IdPelicula),
    CONSTRAINT fk_Pelicula_IdGenero FOREIGN KEY (IdGenero)
        REFERENCES Genero (IdGenero)
);
CREATE TABLE Sala(
    idSala TINYINT NOT NULL,
    Piso TINYINT UNSIGNED NOT NULL,
    Capacidad SMALLINT NOT NULL,
    PRIMARY KEY (IdSala)
);
CREATE TABLE Proyecciones(
    idProyeccion MEDIUMINT UNSIGNED NOT NULL,
    idPelicula TINYINT NOT NULL,
    Precio DECIMAL (5,2) NOT NULL,
    Fecha DATETIME NOT NULL,
    Nombre VARCHAR (50) NOT NULL,
    IdSala TINYINT NOT NULL,
    PRIMARY KEY (IdProyeccion),
    CONSTRAINT fk_Proyecciones_IdPelicula FOREIGN KEY(IdPelicula)
        REFERENCES Pelicula (IdPelicula),
    CONSTRAINT fk_Proyecciones_IdSala FOREIGN KEY(IdSala)
        REFERENCES Sala (IdSala)
);
CREATE TABLE Cliente(
    DNI INT NOT NULL,
    IdEntrada INT UNSIGNED NOT NULL,
    Nombre VARCHAR (50) NOT NULL,
    Mail VARCHAR (60) NOT NULL,
    Contrasena CHAR (64) NOT NULL,
    PRIMARY KEY (DNI)
);
CREATE TABLE Entrada(
    Identrada INT UNSIGNED NOT NULL,
    IdProyeccion INT NOT NULL,
    Fecha DATETIME NOT NULL,
    DNI INT NOT NULL,
    PRIMARY KEY (IdEntrada),
    CONSTRAINT fk_Entrada_DNI FOREIGN KEY(DNI)
        REFERENCES Cliente (DNI),
    CONSTRAINT fk_Entrada_IdProyeccion FOREIGN KEY(IdProyeccion)
        REFERENCES Proyecciones (IdProyeccion)
);