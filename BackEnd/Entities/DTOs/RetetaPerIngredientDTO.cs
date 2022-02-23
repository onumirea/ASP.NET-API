using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class RetetaPerIngredientDTO
    {
        public Reteta Reteta { get; set; }
        public int Cantitate { get; set; }
        public RetetaPerIngredientDTO(Reteta Reteta, int Cantitate)
        {
            this.Reteta = Reteta;
            this.Cantitate = Cantitate;
        }
    }
}
