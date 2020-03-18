using Entity;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadribolPresentationLayer.Models.Query
{
    public class CompetidorQueryViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Casa Casa { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Funcao Funcao { get; set; }
        public bool Disponivel { get; set; }
        public bool EhAtivo { get; set; }
        public Time Time { get; set; }
        public int? TimeID { get; set; }
    }
}
