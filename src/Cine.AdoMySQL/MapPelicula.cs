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
}
}