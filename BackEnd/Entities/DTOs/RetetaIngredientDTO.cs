using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class RetetaIngredientDTO
    {
        public int RetetaId { get; set; }
        public int IngredientId { get; set; }
        public int Cantitate { get; set; }
        public RetetaIngredientDTO(RetetaIngredient reteta_ingredient)
        {
            this.RetetaId = reteta_ingredient.RetetaId;
            this.IngredientId = reteta_ingredient.IngredientId;
            this.Cantitate = reteta_ingredient.Cantitate;
        }
    }
}
