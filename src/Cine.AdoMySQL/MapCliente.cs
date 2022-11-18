using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Mapeador
{
    public class MapCliente : Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado) : base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente()
            {
                DNI = Convert.ToInt32(fila["DNI"]),
                Nombre = Convert.ToString(fila["Nombre"]),
                Mail = Convert.ToString(fila["Mail"]),
                Contrasena = Convert.ToString(fila["Contrasena"])
            };
        public void AltaCliente(Cliente cliente)
    => EjecutarComandoCon("RegistrarCliente", ConfigurarAltaCliente, cliente);

        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("RegistrarCliente");

            BP.CrearParametro("undni")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(cliente.DNI)
            .AgregarParametro();

            BP.CrearParametro("unnombre")
            .SetTipoVarchar(50)
            .SetValor(cliente.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unmail")
            .SetTipoVarchar(50)
            .SetValor(cliente.Mail)
            .AgregarParametro();

            BP.CrearParametro("uncontrasena")
            .SetTipoVarchar(50)
            .SetValor(cliente.Contrasena)
            .AgregarParametro();
        }
        public Cliente ClienteporDNI(int DNI)
        {
            SetComandoSP("ClienteporDNI");

            BP.CrearParametro("unDNI")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(DNI)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public Cliente? BuscarCliente(string mail, string contrasena)
        {
            SetComandoSP("BuscarCliente");

            BP.CrearParametro("unmail")
            .SetTipoVarchar(60)
            .SetValor(mail)
            .AgregarParametro();


            BP.CrearParametro("uncontrasena")
                .SetTipoVarchar(64)
                .SetValor(contrasena)
                .AgregarParametro();

            Cliente? cliente;

            try
            {
                cliente = ElementoDesdeSP();
            }
            catch (System.Exception)
            {
                cliente = null;
            }

            return cliente;

        }

        public List<Cliente> RegistrarClientes() => ColeccionDesdeTabla();
    }
}