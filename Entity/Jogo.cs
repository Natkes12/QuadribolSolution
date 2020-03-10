using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Jogo
    {
        public int ID { get; set; }
        public virtual Time Time1 { get; set; }
        public int Time1ID { get; set; }
        public virtual Time Time2 { get; set; }
        public int Time2ID { get; set; }
        public DateTime DataJogo { get; set; }
        public int Pontuacao { get; set; }
        public virtual Narrador Narrador { get; set; }
        public int NarradorID { get; set; }
        public bool Encerrado { get; set; }
    }
}
