using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Ani_Experienta { get; set; }
        public ICollection<Reteta> Retete { get; set; }
    }
}
