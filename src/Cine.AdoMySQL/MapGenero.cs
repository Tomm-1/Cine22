using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador;

public class MapGenero : Mapeador<Genero>
{
    public MapGenero(AdoAGBD ado) : base(ado)
    {
        Tabla = "Genero";
    }

    public override Genero ObjetoDesdeFila(DataRow fila)
    => new Genero()
    {
        idGenero = Convert.ToSByte(fila["idGenero"]),
        genero = Convert.ToString(fila["Genero"])
    };

}
