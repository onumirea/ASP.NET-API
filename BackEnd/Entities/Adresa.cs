using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities
{
    public class Adresa
    {
        public int Id { get; set; }
        public string Judet { get; set; }
        public string Oras { get; set; }
        public string Strada { get; set; }
        public int Numar { get; set; }
        public string Cod_Postal { get; set; }
        public int MagazinId { get; set; }
        public Magazin Magazin { get; set; }
    }
}
