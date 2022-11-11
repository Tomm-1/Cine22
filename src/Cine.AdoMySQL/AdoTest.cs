using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using et12.edu.ar.AGBD.Ado;
using Mapeador;
using Cine.Core;
using Cine.Core.Ado;

namespace Cine.Test
{
    public class AdoTest : IAdo
    {
        public AdoAGBD Ado { get; set; }
        public MapGenero MapGenero { get; set; }
        public MapSala MapSala { get; set; }
        public MapPelicula MapPelicula { get; set; }
        public MapCliente MapCliente { get; set; }
        public MapProyeccion MapProyeccion { get; set; }
        public AdoTest(AdoAGBD ado)
        {
            Ado = ado;
            MapGenero = new MapGenero(Ado);
            MapSala = new MapSala(Ado);
            MapPelicula = new MapPelicula(Ado);
            MapCliente = new MapCliente(Ado);
            MapProyeccion = new MapProyeccion(Ado);
        }
        public void AltaGenero(Genero genero) => MapGenero.AltaGenero(genero);
        public List<Genero> ObtenerGeneros() => MapGenero.ObtenerGeneros();
        public void AltaSala(Sala sala) => MapSala.AltaSala(sala);
        public List<Sala> ObtenerSalas() => MapSala.ObtenerSalas();
        public void AltaPelicula(Pelicula pelicula) => MapPelicula.AltaPelicula(pelicula);
        public List<Pelicula> ObtenerPeliculas() => MapPelicula.ObtenerPeliculas();
        public void AltaCliente(Cliente cliente) => MapCliente.AltaCliente(cliente);
        public List<Cliente> RegistrarClientes() => MapCliente.RegistrarClientes();
        public void AltaProyeccion(Proyeccion proyeccion) => MapProyeccion.AltaProyeccion(proyeccion);
        public List<Proyeccion> ObtenerProyecciones() => MapProyeccion.ObtenerProyecciones();
    }
}