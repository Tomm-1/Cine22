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
                idPelicula = Convert.ToSByte(fila["idPelicula"]),
                Nombre = Convert.ToString(fila["Nombre"]),
                Lanzamiento = Convert.ToDateTime(fila["Lanzamiento"]),
                idGenero = Convert.ToSByte(fila["idGenero"])
            };
        public void AltaPelicula(Pelicula pelicula)
    => EjecutarComandoCon("altaPelicula", ConfigurarAltaPelicula, PostAltaPelicula, pelicula);

        public void ConfigurarAltaPelicula(Pelicula pelicula)
        {
            SetComandoSP("altaPelicula");

            BP.CrearParametro("unidPelicula")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(pelicula.idPelicula)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetTipoVarchar(50)
            .SetValor(pelicula.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unLanzamiento")
            .SetValor(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(pelicula.Lanzamiento)
            .AgregarParametro();

            BP.CrearParametro("unidGenero")
            .SetValor(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(pelicula.idGenero)
            .AgregarParametro();
        }
        public void PostAltaPelicula(Pelicula pelicula)
        {
            var paramIdPelicula = GetParametro("unidPelicula");
            pelicula.idPelicula = Convert.ToSByte(paramIdPelicula.Value);
        }
        public Pelicula PeliculaPorId(sbyte idPelicula)
        {
            SetComandoSP("PeliculaPorId");

            BP.CrearParametro("unidPelicula")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(idPelicula)
            .AgregarParametro();

            return ElementoDesdeSP();
        }

        public List<Pelicula> ObtenerPeliculas() => ColeccionDesdeTabla();
    }
}