using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class CreateRetetaIngredientDTO
    {
        public int RetetaId { get; set; }
        public int IngredientId { get; set; }
        public int Cantitate { get; set; }
    }
}
