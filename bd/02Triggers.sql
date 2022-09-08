-- Realizar un trigger que verifique que al momento de insertar una entrada,
-- no sobrepase la cantidad de entradas vendidas para la capacidad de la sala 
-- correspondiente a la proyección, en ese caso no se debe permitir la operación
--  y se tiene que mostrar la leyenda “Sala Llena”.

DELIMITER $$
DROP TRIGGER IF EXISTS BefInsEntrada $$
CREATE TRIGGER BefInsEntrada BEFORE INSERT ON Entrada
FOR EACH ROW
BEGIN
	DECLARE TotalVendidas SMALLINT;
    SELECT COUNT(idEntrada) INTO TotalVendidas
    FROM   Proyeccion
	JOIN  Entrada USING (idProyeccion)
    WHERE   idProyeccion = NEW.idProyeccion;
    IF (EXISTS  (SELECT *
                FROM    Proyeccion
                JOIN  Sala USING (idSala)
                WHERE    TotalVendidas = Capacidad)) THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Sala Llena';
	END IF;
END $$


-- Realizar un trigger para que cada vez que se da de alta una película nueva, 
-- se crea una proyección por cada sala y para la fecha y hora de creación.

DROP TRIGGER IF EXISTS aftInsPelicula $$
CREATE TRIGGER aftInsPelicula AFTER INSERT ON Pelicula
FOR EACH ROW
BEGIN
    INSERT INTO Proyeccion (idPelicula, Precio, Fecha, Nombre, idSala)
        SELECT NEW.idPelicula,1000,now(),NEW.Nombre, idSala
        FROM Sala;
END $$
