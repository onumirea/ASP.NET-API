using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities
{
    public class RetetaIngredient
    {
        public int RetetaId { get; set; }
        public Reteta Reteta { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Cantitate { get; set; }
    }
}
