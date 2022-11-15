namespace Cine.Core.Ado;

public interface IAdo
{
    void AltaGenero(Genero genero);
    List<Genero> ObtenerGeneros();
    void AltaSala(Sala sala);
    List<Sala> ObtenerSalas();
    void AltaCliente(Cliente cliente);
    List<Cliente> RegistrarClientes();
    void AltaProyeccion(Proyeccion proyeccion);
    List<Proyeccion> ObtenerProyecciones();
    void AltaPelicula(Pelicula pelicula);
    List<Pelicula> ObtenerPeliculas();
    void AltaEntrada(Entrada entrada);
    List<Entrada> VenderEntradas();
}
