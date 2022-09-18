using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nature.Models
{
    [Table(nameof(SerVivo))]
    public class SerVivo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Caracteristicas { get; set; }
        public String Ambiente { get; set; }
        public int GeneroId  { get; set; }
        public virtual Genero Genero { get; set; }

        public byte[] Imagem { get; set; }
    }
}
