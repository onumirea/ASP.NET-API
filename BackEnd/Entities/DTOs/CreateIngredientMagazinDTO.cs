using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class CreateIngredientMagazinDTO
    {
        public int IngredientId { get; set; }
        public int MagazinId { get; set; }
        public int Pret { get; set; }
    }
}
