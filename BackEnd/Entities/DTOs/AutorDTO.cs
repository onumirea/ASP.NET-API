using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Ani_Experienta { get; set; }
        public List<Reteta> Retete { get; set; }
        public AutorDTO(Autor autor)
        {
            this.Id = autor.Id;
            this.Nume = autor.Nume;
            this.Prenume = autor.Prenume;
            this.Ani_Experienta = autor.Ani_Experienta;
            this.Retete = new List<Reteta>();
        }
    }
}
