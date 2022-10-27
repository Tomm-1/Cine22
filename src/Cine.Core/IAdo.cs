using System.Collections.Generic;
using Cine.Core;

namespace Cine.Core.Ado
{
    public interface IAdo
    {
        void Altasala(Sala sala);
        List<Sala> ObtenerSala();
        
    }
}
