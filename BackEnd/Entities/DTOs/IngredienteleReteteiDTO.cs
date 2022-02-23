using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class IngredienteleReteteiDTO
    {
        public Reteta Reteta;
        public List<IngredientPerRetetaDTO> IngredienteleRetetei;
        public IngredienteleReteteiDTO(Reteta Reteta, List<IngredientPerRetetaDTO> IngredienteleRetetei)
        {
            this.Reteta = Reteta;
            this.IngredienteleRetetei = IngredienteleRetetei;
        }
    }
}
