namespace Cine.Core.Ado;

public interface IAdo
{
    void Altasala(Sala sala);
    List<Sala> ObtenerSalas();
    
    void AltaGenero(Genero genero);
    List<Genero> ObtenerGeneros();
}
