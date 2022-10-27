using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Proyeccion
    {
        public uint idProyeccion { get; set; }
        public sbyte idPelicula { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public sbyte idSala { get; set; }


    }
}