using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class MagazinPerIngredientDTO
    {
        public Magazin Magazin { get; set; }
        public int Pret { get; set; }
        public MagazinPerIngredientDTO(Magazin Magazin, int Pret)
        {
            this.Magazin = Magazin;
            this.Pret = Pret;
        }
    }
}
