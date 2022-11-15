namespace Cine.Core;
public class Genero
{
    public sbyte idGenero { get; set; }
    public string genero { get; set; }
    public Genero(sbyte idGenero, string genero)
    {
        this.idGenero = idGenero;
        this.genero = genero;
    }
    public Genero()
    {
    }
}
