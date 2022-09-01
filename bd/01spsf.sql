-- Se pide hacer los SP para dar de alta todas las entidades (menos Entrada y Cliente) con el prefijo ‘alta’.
DELIMITER $$
DROP PROCEDURE IF EXISTS altasala $$
CREATE PROCEDURE altasala (unidsala TINYINT, unpiso TINYINT UNSIGNED, uncapacidad SMALLINT)
begin
insert Sala (idSala, Piso, Capacidad)
values (unidsala, unpiso, uncapacidad);
end $$

DELIMITER $$
drop procedure if exists altagenero $$
create procedure altagenero(unidgenero tinyint, ungenero varchar(45))
begin 
insert Genero (idGenero, Genero)
values (unidgenero, ungenero);
end$$

DELIMITER $$
drop procedure if exists altapelicula $$
create procedure altapelicula (unidpelicula smallint, unnombre varchar (50), unlanzamiento date, unidgenero tinyint)
begin 
insert Pelicula (idPelicula, Nombre, Lanzamiento, idGenero)
values (unidpelicula, unnombre, unlanzamiento, unidgenero);
end $$

DELIMITER $$
drop procedure if exists altaproyecciones $$
create procedure altaproyecciones (unidproyeccion mediumint unsigned, unidpelicula smallint, unprecio decimal (5.2), unfecha datetime, unnombre varchar (50), unidsala tinyint)
begin 
	insert Proyeccion (idProyeccion, idPelicula, Precio, Fecha, Nombre, idSala)
	values (unidproyeccion, unidpelicula, unprecio, unfecha, unnombre, unidsala);
end $$


-- Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256.
DELIMITER $$
drop procedure if exists registrarCliente $$
create procedure registrarCliente (undni int, unnombre varchar (50), unmail varchar (50), uncontrasena char(64))
begin
	insert into Cliente (DNI, Nombre, Mail, Contrasena)
	VALUES (undni, unnombre, unmail, Sha2(uncontrasena, 256));
end $$

-- Se pide hacer el SP ‘venderEntrada’ que reciba por parámetro el id de la función, valor e identificación del cliente. 
-- Pensar en cómo hacer para darle valores consecutivos desde 1 al número de entrada por función.

DELIMITER $$
drop procedure if exists venderEntrada $$
create procedure venderEntrada (unidproyeccion Mediumint Unsigned, unDNI int)
begin
	insert into Entrada(idProyeccion, DNI)
		values (unidProyeccion, unDNI);
end $$


-- Realizar el SP ‘top10’ que reciba por parámetro 2 fechas, el SP tiene que devolver identificador y nombre de la película y 
-- la cantidad de entradas vendidas para la misma entre las 2 fechas. Ordenar por cantidad de entradas de mayor a menor.

DELIMITER $$
drop procedure if exists top10 $$
create procedure top10 (Fecha1 DateTime, Fecha2 DateTime)
begin 
SELECT pe.idPelicula, pe.Nombre, COUNT(idEntrada)
FROM Entrada e
JOIN Proyeccion p on e.idProyeccion = p.idProyeccion
JOIN Pelicula pe on p.idPelicula = pe.idPelicula
WHERE Fecha BETWEEN Fecha1 AND Fecha2
ORDER BY Fecha desc
LIMIT 10;
end $$

-- Realizar el SF llamado ‘RecaudacionPara’ que reciba por parámetro un identificador de película y 2 fechas, la función 
-- tiene que retornar la recaudación de la película entre esas 2 fechas.

DELIMITER $$
drop function if exists RecaudacionPara $$
create function RecaudacionPara (unidpelicula smallint, Fecha1 DateTime, Fecha2 DateTime)
returns decimal (9,2) reads sql data
begin 
	declare recaudacion  decimal(9,2);
	select SUM(Precio) into recaudacion 
	FROM Proyeccion p
	JOIN Entrada e on e.idProyeccion = p.idProyeccion
	WHERE Fecha BETWEEN Fecha1 AND Fecha2;
	RETURN recaudacion;
end $$