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
    public void AltaGenero(Genero genero)
        => EjecutarComandoCon("altaGenero", ConfigurarAltagenero, PostAltaGenero, genero);

    public void ConfigurarAltagenero(Genero genero)
    {
        SetComandoSP("altaGenero");

        BP.CrearParametroSalida("unidGenero")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .AgregarParametro();

        BP.CrearParametro("ungenero")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.String)
        .SetValor(genero.genero)
        .AgregarParametro();
    }
    public void PostAltaGenero(Genero genero)
    {
        var paramIdGenero = GetParametro("unidGenero");
        genero.idGenero = Convert.ToSByte(paramIdGenero.Value);
    }
    public Genero GeneroPorId(sbyte idGenero)
    {
        SetComandoSP("GeneroPorId");

        BP.CrearParametro("unidGenero")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .SetValor(idGenero)
        .AgregarParametro();

        return ElementoDesdeSP();
    }

    public List<Genero> ObtenerGeneros() => ColeccionDesdeTabla();
}
