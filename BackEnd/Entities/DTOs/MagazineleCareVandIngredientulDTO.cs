using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class MagazineleCareVandIngredientulDTO
    {
        public Ingredient Ingredient;
        public List<MagazinPerIngredientDTO> MagazineleCareVandIngredientul;
        public MagazineleCareVandIngredientulDTO(Ingredient Ingredient, List<MagazinPerIngredientDTO> MagazineleCareVandIngredientul)
        {
            this.Ingredient = Ingredient;
            this.MagazineleCareVandIngredientul = MagazineleCareVandIngredientul;
        }
    }
}
