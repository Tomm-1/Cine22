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
create procedure registrarCliente (undni int, unnombre varchar (50), unmail varchar (50), uncontrasena char(64))
begin
	insert into Cliente (dni, nombre, mail, contrasena)
	VALUES (undni, unnombre, unmail, Sha2(uncontrasena, 256));
end $$

DELIMITER $$
drop procedure if exists venderEntrada $$
create procedure venderEntrada (unidEntrada int, unidproyeccion Mediumint Unsigned, unprecio decimal(9,2), unDNI int, unidEntrada int)
begin
	insert into Entrada(idEntrada, idProyeccion, dni)
		values (unidEntrada,unidProyeccion, undni);
		SELECT COUNT(*) INTO idEntrada
		FROM Entrada
		WHERE COUNT(*) = idEntrada
end $$

DELIMITER $$
drop procedure if exists top10 $$
create procedure top10 (Fecha1 DateTime, Fecha2 DateTime, unidPelicula Smallint, unNombre VARCHAR(50))
begin 
SELECT idPelicula, Nombre, COUNT(idEntrada)
FROM entrada e
JOIN Proyeccion p on e.idProyeccion = p.idProyeccion
JOIN Pelicula pe on p.idPelicula = pe.idPelicula
WHERE COUNT(idEntrada) BETWEEN Fecha1 AND Fecha2

end $$

DELIMITER $$
drop function if exists RecaudacionPara $$
create function RecaudacionPara (unidpelicula smallint, Fecha1 DateTime, Fecha2 DateTime)
returns decimal (9,2) reads sql data
begin 
	declare recaudacion  decimal(9,2);
	select count (*) into recaudacion 
	FROM proyeccion p
	JOIN Entrada e on e.idProyeccion = p.idProyeccion
	WHERE count(*) BETWEEN Fecha1 AND Fecha2
	RETURNS recaudacion;
end $$
