using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class RecenziileReteteiDTO
    {
        public Reteta Reteta;
        public RecenziileReteteiDTO(Reteta Reteta, List<Recenzie> Recenzii)
        {
            this.Reteta = Reteta;
            this.Reteta.Recenzii = Recenzii;
        }
    }
}
