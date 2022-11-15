using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador;

public class MapEntrada : Mapeador<Entrada>
{
    public MapEntrada(AdoAGBD ado) : base(ado)
    {
        Tabla = "Entrada";
    }

    public override Entrada ObjetoDesdeFila(DataRow fila)
    => new Entrada()
    {
        idEntrada = Convert.ToUInt16(fila["idEntrada"]),
        idProyeccion = Convert.ToUInt16(fila["idProyeccion"]),
        DNI = Convert.ToInt16(fila["DNI"])
    };
    public void AltaEntrada(Entrada entrada)
        => EjecutarComandoCon("altaEntrada", ConfigurarAltaEntrada, PostAltaEntrada, entrada);

    public void ConfigurarAltaEntrada(Entrada entrada)
    {
        SetComandoSP("altaEntrada");

        BP.CrearParametro("unidEntrada")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(entrada.idEntrada)
        .AgregarParametro();

        BP.CrearParametro("unidProyeccion")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(entrada.idProyeccion)
        .AgregarParametro();

        BP.CrearParametro("unDNI")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
        .SetValor(entrada.DNI)
        .AgregarParametro();
    }
    public void PostAltaEntrada(Entrada entrada)
    {
        var paramIdEntrada = GetParametro("unidEntrada");
        entrada.idEntrada = Convert.ToUInt16(paramIdEntrada.Value);
    }
    public Entrada EntradaPorId(uint idEntrada)
    {
        SetComandoSP("EntradaPorId");

        BP.CrearParametro("unidEntrada")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(idEntrada)
        .AgregarParametro();

        return ElementoDesdeSP();
    }

    public List<Entrada> VenderEntradas() => ColeccionDesdeTabla();
}