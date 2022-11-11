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
        {
            idProyeccion = Convert.ToUInt16(fila["unidProyeccion"]);

        }
    }
}