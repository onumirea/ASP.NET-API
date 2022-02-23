using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class CreateMagazinDTO
    {
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public Adresa Adresa { get; set; }
    }
}
