using et12.edu.ar.AGBD.Ado;
using Cine.Core;

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
        var genero = new Genero(2, "Drama");
        Ado.AltaGenero(genero);
        Assert.Equal(2, genero.idGenero);
    }

    [Theory]
    [InlineData(1, "TERROR")]
    public void TraerGeneros(sbyte idGenero, string genero)
    {
        var generos = Ado.ObtenerGeneros();
        Assert.Contains(generos, g => g.idGenero == idGenero && g.genero == genero);
    }
}
