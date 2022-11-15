using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador
{
    public class MapProyeccion : Mapeador<Proyeccion>
    {
        public MapProyeccion(AdoAGBD ado) : base(ado)
        {
            Tabla = "Proyeccion";
        }
        public override Proyeccion ObjetoDesdeFila(DataRow fila)
        => new Proyeccion()
        {
            idProyeccion = Convert.ToUInt16(fila["unidProyeccion"]),
            idPelicula = Convert.ToSByte(fila["idPelicula"]),
            Fecha = Convert.ToDateTime(fila["Fecha"]),
            Precio = Convert.ToDecimal(fila["Precio"]),
            idSala = Convert.ToSByte(fila["idSala"])
        };
        public void AltaProyeccion(Proyeccion proyeccion)
        => EjecutarComandoCon("altaproyeccion", ConfigurarAltaProyeccion, PostAltaProyeccion, proyeccion);

        public void ConfigurarAltaProyeccion(Proyeccion proyeccion)
        {
            SetComandoSP("altaproyeccion");

            BP.CrearParametro("unidProyeccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(proyeccion.idProyeccion)
            .AgregarParametro();

            BP.CrearParametro("unidPelicula")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(proyeccion.idPelicula)
            .AgregarParametro();

            BP.CrearParametro("unPrecio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Decimal)
            .SetValor(proyeccion.Precio)
            .AgregarParametro();

            BP.CrearParametro("unFecha")
            .SetValor(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(proyeccion.Fecha)
            .AgregarParametro();

            BP.CrearParametro("unidSala")
            .SetValor(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(proyeccion.idSala)
            .AgregarParametro();
        }
        public void PostAltaProyeccion(Proyeccion proyeccion)
        {
            var paramIdProyeccion = GetParametro("idProyeccion");
            proyeccion.idProyeccion = Convert.ToUInt16(paramIdProyeccion.Value);
        }
        public Proyeccion ProyeccionPorId(uint idProyeccion)
        {
            SetComandoSP("ProyeccionPorId");

            BP.CrearParametro("unidProyeccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(idProyeccion)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Proyeccion> ObtenerProyecciones() => ColeccionDesdeTabla();
    }
}