using et12.edu.ar.AGBD.Ado;
using Cine.Core;

namespace Cine.Test;

public class SalaTest
{
    public AdoTest Ado { get; set; }
    public SalaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaSala()
    {
        var sala = new Sala(3, 2, 10);
        Ado.AltaSala(sala);
        Assert.Equal(3, sala.idSala);
    }
    [Theory]
    [InlineData(1, 1, 10)]
    [InlineData(2, 1, 10)]
    public void TraerSalas(sbyte idSala, sbyte Piso, short Capacidad)
    {
        var salas = Ado.ObtenerSalas();
        Assert.Contains(salas, s => s.idSala == idSala && s.Piso == Piso && s.Capacidad == Capacidad);
    }
}