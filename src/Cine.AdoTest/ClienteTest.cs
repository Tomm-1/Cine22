using et12.edu.ar.AGBD.Ado;
using Cine.Core;

namespace Cine.Test;
public class ClienteTest
{
    public AdoTest Ado { get; set; }
    public ClienteTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }
    [Fact]
    public void AltaCliente()
    {
        var cliente = new Cliente("tomiuwu", 12341, "esta", "esta123");
        Ado.AltaCliente(cliente);
        Assert.Equal(12341, cliente.DNI);
    }

    [Theory]
    [InlineData(41534607)]
    public void TraerClientes(int DNI)
    {
        var clientes = Ado.RegistrarClientes();
        Assert.Contains(clientes, c => c.DNI == DNI);
    }

    public void TrearBuscarCLiente(int DNI)
    {
        var clientes = Ado.RegistrarClientes();
        Assert.Contains(clientes, c => c.DNI == DNI);
    }


    [Fact]
    public void ObtenerBuscarCliente()
    {
        var cliente = Ado.BuscarCliente("uvuonug41@gmail.com", "hailgrasa");
        Assert.Equal("uvuonug41@gmail.com", cliente.Mail);
    }
}