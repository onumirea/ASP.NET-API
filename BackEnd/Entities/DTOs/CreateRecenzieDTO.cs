using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class CreateRecenzieDTO
    {
        public int Id { get; set; }
        public string Continut { get; set; }
        public int Rating { get; set; }
        public int RetetaId { get; set; }

    }
}
