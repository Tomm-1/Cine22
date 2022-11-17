using et12.edu.ar.AGBD.Ado;
using Cine.Core;

namespace Cine.Test;
public class PeliculaTest
{
    public AdoTest Ado { get; set; }
    public PeliculaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaPelicula()
    {
        DateTime ahora = new DateTime(2022, 11, 10);
        var pelicula = new Pelicula(3, "Black Adam", ahora, 1);
        Ado.AltaPelicula(pelicula);
        Assert.Equal(3, pelicula.idPelicula);
    }

    [Theory]
    [InlineData(2)]
    public void TraerPeliculas(sbyte idPelicula)
    {
        var peliculas = Ado.ObtenerPeliculas();
        Assert.Contains(peliculas, p => p.idPelicula == idPelicula);
    }
}
