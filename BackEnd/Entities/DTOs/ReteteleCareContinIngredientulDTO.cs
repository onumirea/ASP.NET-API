using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class ReteteleCareContinIngredientulDTO
    {
        public Ingredient Ingredient;
        public List<RetetaPerIngredientDTO> ReteteleCareContinIngredientul;
        public ReteteleCareContinIngredientulDTO(Ingredient Ingredient, List<RetetaPerIngredientDTO> ReteteleCareContinIngredientul)
        {
            this.Ingredient = Ingredient;
            this.ReteteleCareContinIngredientul = ReteteleCareContinIngredientul;
        }
    }
}
