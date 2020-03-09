using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Narrador
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public bool EhAtivo { get; set; }
        public virtual ICollection<Jogo> Jogos { get; set; }

        public Narrador()
        {
            this.Jogos = new List<Jogo>();
        }
    }
}
