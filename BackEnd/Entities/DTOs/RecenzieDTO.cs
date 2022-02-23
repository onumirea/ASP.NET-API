using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class RecenzieDTO
    {
        public int Id { get; set; }
        public string Continut { get; set; }
        public int Rating { get; set; }
        public int RetetaId { get; set; }
        public RecenzieDTO(Recenzie recenzie)
        {
            this.Id = recenzie.Id;
            this.Continut = recenzie.Continut;
            this.Rating = recenzie.Rating;
            this.RetetaId = recenzie.RetetaId;
        }
    }
}
