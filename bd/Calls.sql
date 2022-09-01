-- calls
CALL altasala (1,1,10);
CALL altasala (2,1,10);
CALL altagenero(1,'TERROR');
CALL altapelicula(1,'Rápidos y Furiosos 15 vs minions', '2033/03/03',1);
CALL altapelicula(2,'megamente 2', '2033/02/03',1);
CALL altaproyecciones(1,1,1000,'2033/03/07','Rápidos y Furiosos 15 vs minions',1);
CALL altaproyecciones(2,1,1000,'2033/03/13','megamente 2',1);
CALL altaproyecciones(3,1,1000,'2033/03/07','Rápidos y Furiosos 15 vs minions',2);

CALL registrarCliente (41534607,'uvuvwevwevwe onyetenyevwe ugwemuhwem osas', 'uvuonug41@gmail.com', 'hailgrasa');

CALL venderEntrada(1,41534607);
CALL venderEntrada(3,41534607);

CALL top10('2033/03/03','2033/04/03');

SELECT RecaudacionPara(1,'2033/03/03','2033/04/03') 'RECAUDADO';
