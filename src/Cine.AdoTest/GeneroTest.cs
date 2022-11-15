using et12.edu.ar.AGBD.Ado;
using Cine.Test;
using Cine.Core;
using Mapeador;

namespace Cine.Test;

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
        var genero = new Genero("Drama");
        Ado.AltaGenero(genero);
        Assert.Equal(2, genero.idGenero);
    }

    [Theory]
    [InlineData(1, "TERROR")]
}