using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Unitate_Masura { get; set; }
        public string Categorie { get; set; }
        public List<RetetaIngredient> RetetaIngrediente { get; set; }
        public List<IngredientMagazin> IngredientMagazine { get; set; }
        public IngredientDTO(Ingredient ingredient)
        {
            this.Id = ingredient.Id;
            this.Nume = ingredient.Nume;
            this.Unitate_Masura = ingredient.Unitate_Masura;
            this.Categorie = ingredient.Categorie;
            this.RetetaIngrediente = new List<RetetaIngredient>();
            this.IngredientMagazine = new List<IngredientMagazin>();
        }
    }
}
