using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nature.Models
{
    public class SerViewModel
    {
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Caracteristicas { get; set; }
        [Required]
        public String Ambiente { get; set; }
        [Required]
        public HttpPostedFileBase ImageUpload { get; set; }
        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }

    }
}
