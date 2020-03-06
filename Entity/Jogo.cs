using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Jogo
    {
        public int ID { get; set; }
        public Time[] Times { get; set; }
        public DateTime DataJogo { get; set; }
        public int Pontuacao { get; set; }
        public Narrador Narrador { get; set; }
    }
}
