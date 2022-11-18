using et12.edu.ar.AGBD.Ado;
using Cine.Core;

namespace Cine.Test;

public class EntradaTest
{
    public AdoTest Ado { get; set; }
    public EntradaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaEntrada()
    {
        var entrada = new Entrada(1, 4, 41534607);
        Ado.AltaEntrada(entrada);
        Assert.Equal((uint)1,entrada.idEntrada);
    }

    [Theory]
    [InlineData(1)]
    public void TraerEntrada(uint idProyeccion)
    {
        var entradas = Ado.VenderEntradas();
        Assert.Contains(entradas, e => e.idProyeccion == idProyeccion);
    }
}