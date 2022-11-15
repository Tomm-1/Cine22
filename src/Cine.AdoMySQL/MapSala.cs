using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador;

public class MapSala : Mapeador<Sala>
{
    public MapSala(AdoAGBD ado) : base(ado)
    {
        Tabla = "Sala";
    }

    public override Sala ObjetoDesdeFila(DataRow fila)
    => new Sala()
    {
        idSala = Convert.ToSByte(fila["idSala"]),
        Piso = Convert.ToSByte(fila["Piso"]),
        Capacidad = Convert.ToSByte(fila["Capacidad"])
    };
    public void AltaSala(Sala sala)
        => EjecutarComandoCon("altaSala", ConfigurarAltaSala, PostAltaSala, sala);

    public void ConfigurarAltaSala(Sala sala)
    {
        SetComandoSP("altaSala");

        BP.CrearParametro("unidSala")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .SetValor(sala.idSala)
        .AgregarParametro();

        BP.CrearParametro("unPiso")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .SetValor(sala.Piso)
        .AgregarParametro();

        BP.CrearParametro("unCapacidad")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .SetValor(sala.Capacidad)
        .AgregarParametro();
    }
    public void PostAltaSala(Sala sala)
    {
        var paramIdSala = GetParametro("unidSala");
        sala.idSala = Convert.ToSByte(paramIdSala.Value);
    }
    public Sala SalaPorId(sbyte idSala)
    {
        SetComandoSP("SalaPorId");

        BP.CrearParametro("unidSala")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .SetValor(idSala)
        .AgregarParametro();

        return ElementoDesdeSP();
    }

    public List<Sala> ObtenerSalas() => ColeccionDesdeTabla();
}