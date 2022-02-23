using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities
{
    public class Informatii_nutritionale
    {
        public int Id { get; set; }
        public int Calorii { get; set; }
        public int Glucide { get; set; }
        public int Proteine { get; set; }
        public int Grasimi { get; set; }
        public int RetetaId { get; set; }
        public Reteta Reteta { get; set; }
    }
}
