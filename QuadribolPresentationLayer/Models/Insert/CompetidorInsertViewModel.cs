using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadribolPresentationLayer.Models.Insert
{
    public class CompetidorInsertViewModel
    {
        public string Nome { get; set; }
        public Casa Casa { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Funcao Funcao { get; set; }
    }
}
