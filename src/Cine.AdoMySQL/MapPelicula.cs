using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador
{
    public class MapPelicula : Mapeador<Pelicula>
    {
        public MapPelicula(AdoAGBD ado) : base(ado)
        {
            Tabla = "Pelicula";
        }
        public override Pelicula ObjetoDesdeFila(DataRow fila)
            => new Pelicula()
            {
                idPelicula = Convert.ToByte(fila["idPelicula"]),
                Nombre = Convert.ToString(fila["Nombre"]),
                Lanzamiento = Convert.ToDateTime(fila["Lanzamiento"]),
                idGenero = Convert.ToByte(fila["idGenero"])
            };
        public void AltaPelicula(Pelicula pelicula)
    => EjecutarComandoCon("altapelicula", ConfigurarAltaPelicula, PostAltaPelicula, pelicula);

        public void ConfigurarAltaPelicula(Pelicula pelicula)
        {
            SetComandoSP("altapelicula");

            BP.CrearParametro("unidpelicula")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(pelicula.idPelicula)
            .AgregarParametro();

            BP.CrearParametro("unnombre")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.String)
            .SetValor(pelicula.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unlanzamiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Date)
            .SetValor(pelicula.Lanzamiento)
            .AgregarParametro();

            BP.CrearParametro("unidgenero")
            .SetValor(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(pelicula.idGenero)
            .AgregarParametro();
        }
        public void PostAltaPelicula(Pelicula pelicula)
        {
            var paramIdPelicula = GetParametro("unidpelicula");
            pelicula.idPelicula = Convert.ToByte(paramIdPelicula.Value);
        }
        public Pelicula PeliculaPorId(sbyte idPelicula)
        {
            SetComandoSP("PeliculaPorId");

            BP.CrearParametro("unidpelicula")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(idPelicula)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public Pelicula? Top10(DateTime Fecha1, DateTime Fecha2)
        {
            SetComandoSP("Top10");

            BP.CrearParametro("Fecha1")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(Fecha1)
            .AgregarParametro();

            BP.CrearParametro("Fecha2")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(Fecha2)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Pelicula> ObtenerPeliculas() => ColeccionDesdeTabla();
    }
}
