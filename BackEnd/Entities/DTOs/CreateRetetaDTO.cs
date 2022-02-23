using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class CreateRetetaDTO
    {
        public string Nume { get; set; }
        public string Grad_Dificultate { get; set; }
        public int Durata_minute { get; set; }
        public int Numar_portii { get; set; }
        public string Categorie { get; set; }
        public string Bucatarie { get; set; }
        public string Mod_preparare { get; set; }
        public int AutorId { get; set; }
        public Informatii_nutritionale Informatii_Nutritionale { get; set; }
    }
}
