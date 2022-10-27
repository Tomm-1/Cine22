using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Cliente
    {
        public Cliente(string nombre, int dni, string mail, string contrasena)
        {
            Nombre = nombre;
            DNI = dni;
            Mail = mail;
            Contrasena = contrasena;


        }
        public int DNI { get; set; }
        public string Nombre { get; set; }

        public string Mail { get; set; }
        public string Contrasena { get; set; }
    }
}