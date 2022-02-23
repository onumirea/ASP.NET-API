using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Entities.DTOs
{
    public class ReteteleAutoruluiDTO
    {
        public Autor Autor;
        public ReteteleAutoruluiDTO(Autor Autor, List<Reteta> Retete)
        {
            this.Autor = Autor;
            this.Autor.Retete = Retete;
        }
    }
}
