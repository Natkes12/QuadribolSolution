using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    [Table("NARRADORES")]
    public class Narrador
    {
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Nome { get; set; }
        public bool EhAtivo { get; set; }
        public virtual ICollection<Jogo> Jogos { get; set; }

        public Narrador()
        {
            this.Jogos = new List<Jogo>();
        }
    }
}
