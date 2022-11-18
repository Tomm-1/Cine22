using et12.edu.ar.AGBD.Ado;
using Cine.Core;

namespace Cine.Test;
public class ProyeccionTest
{
    public AdoTest Ado { get; set; }
    public ProyeccionTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaProyeccion()
    {
        var proyeccion = new Proyeccion(6, 1, 1000, DateTime.Today, 1);
        Ado.AltaProyeccion(proyeccion);
        Assert.Equal(1, proyeccion.idPelicula);
    }
    [Theory]
    [InlineData(5)]
    public void TraerProyecciones(uint idProyeccion)
    {
        var proyecciones = Ado.ObtenerProyecciones();
        Assert.Contains(proyecciones, p => p.idProyeccion == idProyeccion);
    }
}