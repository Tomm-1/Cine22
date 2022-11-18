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
        public AdoTest(AdoAGBD ado, MapSala mapSala, MapProyeccion mapProyeccion, MapEntrada mapEntrada)
        {
            this.Ado = ado;
            this.MapSala = mapSala;
            this.MapProyeccion = mapProyeccion;
            this.MapEntrada = mapEntrada;

        }
        public AdoAGBD Ado { get; set; }
        public MapGenero MapGenero { get; set; }
        public MapSala MapSala { get; set; }
        public MapCliente MapCliente { get; set; }
        public MapProyeccion MapProyeccion { get; set; }
        public MapPelicula MapPelicula { get; set; }
        public MapEntrada MapEntrada { get; set; }
        public AdoTest(AdoAGBD ado)
        {
            Ado = ado;
            MapGenero = new MapGenero(Ado);
            MapSala = new MapSala(Ado);
            MapCliente = new MapCliente(Ado);
            MapProyeccion = new MapProyeccion(Ado);
            MapPelicula = new MapPelicula(Ado);
            MapEntrada = new MapEntrada(Ado);
        }
        public void AltaGenero(Genero genero) => MapGenero.AltaGenero(genero);
        public List<Genero> ObtenerGeneros() => MapGenero.ObtenerGeneros();
        public void AltaSala(Sala sala) => MapSala.AltaSala(sala);
        public List<Sala> ObtenerSalas() => MapSala.ObtenerSalas();
        public void AltaCliente(Cliente cliente) => MapCliente.AltaCliente(cliente);
        public List<Cliente> RegistrarClientes() => MapCliente.RegistrarClientes();
        public void AltaProyeccion(Proyeccion proyeccion) => MapProyeccion.AltaProyeccion(proyeccion);
        public List<Proyeccion> ObtenerProyecciones() => MapProyeccion.ObtenerProyecciones();
        public void AltaPelicula(Pelicula pelicula) => MapPelicula.AltaPelicula(pelicula);
        public List<Pelicula> ObtenerPeliculas() => MapPelicula.ObtenerPeliculas();
        public void AltaEntrada(Entrada entrada) => MapEntrada.AltaEntrada(entrada);
        public List<Entrada> VenderEntradas() => MapEntrada.VenderEntradas();
        public Cliente? BuscarCliente(string email, string contrasena) => MapCliente.BuscarCliente(email, contrasena);

    }
}