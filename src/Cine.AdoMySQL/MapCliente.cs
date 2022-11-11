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
                DNI = Convert.ToInt16(fila["DNI"]),
                Nombre = Convert.ToString(fila["Nombre"]),
                Mail = Convert.ToString(fila["Mail"]),
                Contrasena = Convert.ToString(fila["idGenero"])
            };
        public void AltaCliente(Cliente cliente)
    => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);

        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("altaCliente");

            BP.CrearParametro("unDNI")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(cliente.DNI)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetTipoVarchar(50)
            .SetValor(cliente.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unMail")
            .SetTipoVarchar(50)
            .SetValor(cliente.Mail)
            .AgregarParametro();

            BP.CrearParametro("uncontrasena")
            .SetValor(MySql.Data.MySqlClient.MySqlDbType.String)
            .SetValor(cliente.Contrasena)
            .AgregarParametro();
        }
        public void PostAltaCliente(Cliente cliente)
        {
            var paramDNI = GetParametro("unDNI");
            cliente.DNI = Convert.ToSByte(paramDNI.Value);
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

        public List<Cliente> RegistrarClientes() => ColeccionDesdeTabla();
    }
}