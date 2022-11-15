using et12.edu.ar.AGBD.Ado;
using Cine.Test;
using Cine.AdoTest

namespace Cine.AdoTest;

public class GeneroTest
{
    public AdoTest Ado { get; set; }
    public GeneroTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaGenero()
    {
        var genero = new Genero("Terror");
        Ado.AltaGenero(genero);
        Assert.Equal()
    }
}