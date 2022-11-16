namespace Cine.Core;
public class Entrada
{
    public uint idEntrada { get; set; }
    public uint idProyeccion { get; set; }
    public int DNI { get; set; }
    public Entrada(uint idEntrada, uint idProyeccion, int DNI)
    {
        this.idEntrada = idEntrada;
        this.idProyeccion = idProyeccion;
        this.DNI = DNI;
    }
    public Entrada()
    {
    }
}
