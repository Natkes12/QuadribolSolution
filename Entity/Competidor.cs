using Entity.Enums;
using System;

namespace Entity
{
    public class Competidor
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Casa Casa { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Funcao Funcao { get; set; }
        public bool Disponivel { get; set; }
        public bool EhAtivo { get; set; }
    }

}
