using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities
{
    public class IngredientMagazin
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int MagazinId { get; set; }
        public Magazin Magazin { get; set; }
        public int Pret { get; set; }

    }
}
