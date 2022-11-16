using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Cliente
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Contrasena { get; set; }
        public Cliente(string Nombre, int DNI, string mail, string contrasena)
        {
            this.Nombre = Nombre;
            this.DNI = DNI;
            this.Mail = mail;
            this.Contrasena = contrasena;
        }
        public Cliente()
        {

        }
    }
}