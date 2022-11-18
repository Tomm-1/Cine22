using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Pelicula
    {
        public byte idPelicula { get; set; }
        public string Nombre { get; set; }
        public DateTime Lanzamiento { get; set; }
        public byte idGenero { get; set; }

        public Pelicula(byte idPelicula, string Nombre, DateTime Lanzamiento, byte idGenero)
        {
            this.idPelicula = idPelicula;
            this.Nombre = Nombre;
            this.Lanzamiento = Lanzamiento;
            this.idGenero = idGenero;
        }
        public Pelicula()
        {
        }
    }
}