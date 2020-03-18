using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    [Table("TIMES")]
    public class Time
    {
        public int ID { get; set; }
        public Casa Casa { get; set; }
        public ICollection<Competidor> Competidores { get; set; }
        public virtual ICollection<JogoTime> JogosTime { get; set; }

        public Time()
        {
            this.JogosTime = new List<JogoTime>();
        }
    }
}
