DELIMITER $$
DROP PROCEDURE IF EXISTS altasala $$
CREATE PROCEDURE altasala (unidsala TINYINT, unpiso TINYINT UNSIGNED, uncapacidad SMALLINT)
begin
insert sala (idsala, piso, capacidad)
values (unidsala, unpiso, uncapacidad);
end $$

DELIMITER $$
drop procedure if exists altagenero $$
create procedure altagenero(unidgenero tinyint, ungenero varchar(45))
begin 
insert genero (idgenero, genero)
values (unidgenero, ungenero);
end$$

DELIMITER $$
drop procedure if exists altapelicula $$
create procedure altapelicula (unidpelicula smallint, unnombre varchar (50), unlanzamiento date, unidgenero tinyint)
begin 
insert pelicula (idpelicula, nombre, lanzamiento, idgenero)
values (unidpelicula, unnombre, unlanzamiento, unidgenero);
end $$

DELIMITER $$
drop procedure if exists altaproyecciones $$
create procedure altaproyecciones (unidproyeccion mediumint unsigned, unidpelicula smallint, unprecio decimal (5.2), unfecha datetime, unnombre varchar (50), unidsala tinyint)
begin 
insert proyecciones (idproyeccion, idpelicula, precio, fecha, nombre, idsala)
values (unidproyeccion, unidpelicula, unprecio, unfecha, unnombre, unidsala);
end $$

DELIMITER $$
drop procedure if exists registrarCliente $$
create procedure registrarCliente (IN undni int, unidentrada int, unnombre varchar (50), unmail varchar (50), uncontrasena char(64))
begin
insert registrarCliente (dni, identrada, nombre, mail, contrasena)
VALUES (undni, unidentrada, unnombre, unmail, Sha2(uncontrasena, 256));
end $$

DELIMITER $$
drop procedure if exists venderEntrada $$
create procedure venderEntrada (unidproyeccion Mediumint Unsigned, unvalor decimal(5,2), unDNI int, unididEntrada int)
begin
	insert into Entrada (idProyeccion, fecha, dni)
		values (unidProyeccion, unfecha, undni);
		
        UPDATE idEntrada SET idEntrada = LAST_INSERT_ID() WHERE idEntrada =unididEntrada;
end $$

DELIMITER $$
drop procedure if exists top10 $$
create procedure top10 (Fecha1 DateTime, Fecha2 DateTime, unidPelicula Smallint, unNombre VARCHAR(50))
begin 
SELECT idPelicula, Nombre, COUNT(idEntrada)
FROM entrada e
JOIN Proyeccion p on e.idProyeccion = p.idProyeccion
JOIN Pelicula pe on p.idPelicula = pe.idPelicula
WHERE Fecha1 < Fecha AND fecha2 > Fecha;

end $$

DELIMITER $$
drop function if exists RecaudacionPara $$
create function RecaudacionPara (in unidpelicula smallint, Fecha1 DateTime, Fecha2 DateTime)
returns decimal reads sql data
begin 
declare recaudacion  decimal
select count (*) into recaudacion 
FROM proyeccion p
JOIN Entrada e on e.idProyeccion = p.idProyeccion
JOIN Cliente c on e.idEntrada = c.idEntrada
WHERE Fecha1 < Fecha AND fecha2 > Fecha ;
RETURNS recaudacion;
end $$
