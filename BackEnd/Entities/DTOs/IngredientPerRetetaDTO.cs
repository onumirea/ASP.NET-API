using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class IngredientPerRetetaDTO
    {
        public Ingredient Ingredient { get; set; }
        public int Cantitate { get; set; }
        public IngredientPerRetetaDTO(Ingredient Ingredient, int Cantitate)
        {
            this.Ingredient = Ingredient;
            this.Cantitate = Cantitate;
        }
    }
}
