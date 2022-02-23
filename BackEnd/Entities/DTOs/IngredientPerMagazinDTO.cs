using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class IngredientPerMagazinDTO
    {
        public Ingredient Ingredient { get; set; }
        public int Pret { get; set; }
        public IngredientPerMagazinDTO(Ingredient Ingredient, int Pret)
        {
            this.Ingredient = Ingredient;
            this.Pret = Pret;
        }
    }
}
