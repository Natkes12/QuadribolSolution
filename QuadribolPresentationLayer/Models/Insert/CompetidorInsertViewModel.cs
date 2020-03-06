using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadribolPresentationLayer.Models.Insert
{
    public class CompetidorInsertViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Casa Casa { get; set; }
        public string Escolaridade { get; set; }
        public Funcao Funcao { get; set; }
        public bool Disponivel { get; set; }
        public bool EhAtivo { get; set; }
    }
}
