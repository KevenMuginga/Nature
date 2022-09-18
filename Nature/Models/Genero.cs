using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nature.Models
{
    [Table(nameof(Genero))]
    public class Genero
    {
        public int GeneroId { get; set; }
        public String GeneroNome { get; set; }
        public ICollection<SerVivo> Seres { get; set; }
        //public ICollection<SerViewModel> SerModel { get; set; }
    }
}
