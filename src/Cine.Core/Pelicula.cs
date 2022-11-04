using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Pelicula
    {
        public sbyte idPelicula { get; set; }
        public string Nombre { get; set; }
        public DateTime Lanzamiento { get; set; }
        public sbyte idGenero { get; set; }

        public Pelicula(sbyte idPelicula, string Nombre, DateTime Lanzamiento, sbyte idGenero)
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