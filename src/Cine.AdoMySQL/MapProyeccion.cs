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
            idProyeccion = Convert.ToUInt16(fila["idProyeccion"]),
            idPelicula = Convert.ToSByte(fila["idPelicula"]),
            Fecha = Convert.ToDateTime(fila["Fecha"]),
            Precio = Convert.ToDecimal(fila["Precio"]),
            idSala = Convert.ToSByte(fila["idSala"])
        };
        public void AltaProyeccion(Proyeccion proyeccion)
        => EjecutarComandoCon("altaproyecciones", ConfigurarAltaProyeccion, PostAltaProyeccion, proyeccion);

        public void ConfigurarAltaProyeccion(Proyeccion proyeccion)
        {
            SetComandoSP("altaproyecciones");

            BP.CrearParametro("unidproyeccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(proyeccion.idProyeccion)
            .AgregarParametro();

            BP.CrearParametro("unidpelicula")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(proyeccion.idPelicula)
            .AgregarParametro();

            BP.CrearParametro("unprecio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Decimal)
            .SetValor(proyeccion.Precio)
            .AgregarParametro();

            BP.CrearParametro("unfecha")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(proyeccion.Fecha)
            .AgregarParametro();

            BP.CrearParametro("unidsala")
            .SetValor(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(proyeccion.idSala)
            .AgregarParametro();
        }
        public void PostAltaProyeccion(Proyeccion proyeccion)
        {
            var paramIdProyeccion = GetParametro("unidproyeccion");
            proyeccion.idProyeccion = Convert.ToUInt16(paramIdProyeccion.Value);
        }
        public Proyeccion ProyeccionPorId(uint idProyeccion)
        {
            SetComandoSP("ProyeccionPorId");

            BP.CrearParametro("unidproyeccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(idProyeccion)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Proyeccion> ObtenerProyecciones() => ColeccionDesdeTabla();
    }
}