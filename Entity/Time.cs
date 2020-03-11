using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    [Table("Times")]
    public class Time
    {
        public int ID { get; set; }
        public List<Competidor> Competidor { get; set; }
        public Casa Casa { get; set; }
        public virtual ICollection<Jogo> Jogos { get; set; }

        public Time()
        {
            this.Jogos = new List<Jogo>();
        }
    }
}
