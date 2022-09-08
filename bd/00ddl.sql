DROP DATABASE IF EXISTS Cine22;
CREATE DATABASE Cine22;
USE Cine22;
CREATE TABLE Genero(
    idGenero TINYINT NOT NULL,
    Genero VARCHAR (45) NOT NULL,
    PRIMARY KEY (idGenero)
);
CREATE TABLE Pelicula(
    idPelicula TINYINT NOT NULL,
    Nombre VARCHAR (50) NOT NULL,
    Lanzamiento DATE NOT NULL,
    idGenero TINYINT NOT NULL,
    PRIMARY KEY (idPelicula),
    CONSTRAINT fk_Pelicula_idGenero FOREIGN KEY (idGenero)
        REFERENCES Genero (IdGenero)
);
CREATE TABLE Sala(
    idSala TINYINT NOT NULL,
    Piso TINYINT UNSIGNED NOT NULL,
    Capacidad SMALLINT NOT NULL,
    PRIMARY KEY (idSala)
);
CREATE TABLE Proyeccion(
    idProyeccion MEDIUMINT UNSIGNED NOT NULL AUTO_INCREMENT,
    idPelicula TINYINT NOT NULL,
    Precio DECIMAL (9,2) NOT NULL,
    Fecha DATETIME NOT NULL,
    idSala TINYINT NOT NULL,
    PRIMARY KEY (idProyeccion),
    CONSTRAINT fk_Proyeccion_idPelicula FOREIGN KEY(idPelicula)
        REFERENCES Pelicula (IdPelicula),
    CONSTRAINT fk_Proyeccion_idSala FOREIGN KEY(idSala)
        REFERENCES Sala (idSala)
);
CREATE TABLE Cliente(
    DNI INT NOT NULL,
    Nombre VARCHAR (50) NOT NULL,
    Mail VARCHAR (60) NOT NULL,
    Contrasena CHAR (64) NOT NULL,
    PRIMARY KEY (DNI)
);
CREATE TABLE Entrada(
    idEntrada INT UNSIGNED NOT NULL AUTO_INCREMENT,
    idProyeccion MEDIUMINT UNSIGNED  NOT NULL,
    DNI INT NOT NULL,
    PRIMARY KEY (idEntrada),
    CONSTRAINT fk_Entrada_DNI FOREIGN KEY(DNI)
        REFERENCES Cliente (DNI),
    CONSTRAINT fk_Entrada_idProyeccion FOREIGN KEY(idProyeccion)
        REFERENCES Proyeccion (idProyeccion)
);
