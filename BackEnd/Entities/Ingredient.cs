using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Unitate_Masura { get; set; }
        public string Categorie { get; set; }
        public ICollection<RetetaIngredient> RetetaIngrediente { get; set; }
        public ICollection<IngredientMagazin> IngredientMagazine { get; set; }
    }
}
