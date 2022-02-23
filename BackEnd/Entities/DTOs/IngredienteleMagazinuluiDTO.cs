using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class IngredienteleMagazinuluiDTO
    {
        public Magazin Magazin;
        public List<IngredientPerMagazinDTO> IngredienteleMagazinului;
        public IngredienteleMagazinuluiDTO(Magazin Magazin, List<IngredientPerMagazinDTO> IngredienteleMagazinului)
        {
            this.Magazin = Magazin;
            this.IngredienteleMagazinului = IngredienteleMagazinului;
        }
    }
}
