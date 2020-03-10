using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Jogo
    {
        public int ID { get; set; }
        public virtual ICollection<Time> Times { get; set; }
        public int[] TimesID { get; set; }
        public DateTime DataJogo { get; set; }
        public int Pontuacao { get; set; }
        public virtual Narrador Narrador { get; set; }
        public int NarradorID { get; set; }
        public bool Encerrado { get; set; }

        public Jogo()
        {
            this.Times = new Time[2];
            this.TimesID = new int[2];
        }
    }
}
