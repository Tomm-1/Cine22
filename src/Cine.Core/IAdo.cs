namespace Cine.Core.Ado;

public interface IAdo
{

    void AltaSala(Sala sala);
    List<Sala> ObtenerSalas();

    void AltaGenero(Genero genero);
    List<Genero> ObtenerGeneros();
    void AltaPelicula(Pelicula pelicula);
    List<Pelicula> ObtenerPeliculas();

    void AltaCliente(Cliente cliente);
    List<Cliente> RegistrarClientes();

    void AltaProyeccion(Proyeccion proyeccion);
    List<Proyeccion> ObtenerProyecciones();
}
