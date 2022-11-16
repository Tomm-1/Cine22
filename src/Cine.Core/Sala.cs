using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core;

public class Sala
{
    public sbyte idSala { get; set; }
    public sbyte Piso { get; set; }
    public short Capacidad { get; set; }
    public Sala(sbyte idSala, sbyte Piso, short Capacidad)
    {
        this.idSala = idSala;
        this.Piso = Piso;
        this.Capacidad = Capacidad;
    }
    public Sala()
    {
    }
}
