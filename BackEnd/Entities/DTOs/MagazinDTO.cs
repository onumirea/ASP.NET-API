using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class MagazinDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public Adresa Adresa { get; set; }
        public List<IngredientMagazin> IngredientMagazine { get; set; }
        public MagazinDTO(Magazin magazin)
        {
            this.Id = magazin.Id;
            this.Nume = magazin.Nume;
            this.Telefon = magazin.Telefon;
            this.Email = magazin.Email;
            this.Site = magazin.Site;
            this.Adresa = magazin.Adresa;
            this.IngredientMagazine = new List<IngredientMagazin>();
        }
    }
}
