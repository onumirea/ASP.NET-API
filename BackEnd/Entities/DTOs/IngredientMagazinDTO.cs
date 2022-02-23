using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class IngredientMagazinDTO
    {
        public int IngredientId { get; set; }
        public int MagazinId { get; set; }
        public int Pret { get; set; }
        public IngredientMagazinDTO(IngredientMagazin ingredient_magazin)
        {
            this.IngredientId = ingredient_magazin.IngredientId;
            this.MagazinId = ingredient_magazin.MagazinId;
            this.Pret = ingredient_magazin.Pret;
        }
    }
}
