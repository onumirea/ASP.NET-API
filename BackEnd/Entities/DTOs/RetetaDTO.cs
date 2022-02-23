using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class RetetaDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Grad_Dificultate { get; set; }
        public int Durata_minute { get; set; }
        public int Numar_portii { get; set; }
        public string Categorie { get; set; }
        public string Bucatarie { get; set; }
        public string Mod_preparare { get; set; }
        public int AutorId { get; set; }
        public List<Recenzie> Recenzii { get; set; }
        public Informatii_nutritionale Informatii_Nutritionale { get; set; }
        public List<RetetaIngredient> RetetaIngrediente { get; set; }
        public RetetaDTO(Reteta reteta)
        {
            this.Id = reteta.Id;
            this.Nume = reteta.Nume;
            this.Grad_Dificultate = reteta.Grad_Dificultate;
            this.Durata_minute = reteta.Durata_minute;
            this.Categorie = reteta.Categorie;
            this.Bucatarie = reteta.Bucatarie;
            this.Mod_preparare = reteta.Mod_preparare;
            this.AutorId = reteta.AutorId;
            this.Recenzii = new List<Recenzie>();
            this.Informatii_Nutritionale = reteta.Informatii_Nutritionale;
            this.RetetaIngrediente = new List<RetetaIngredient>();
        }
    }
}
