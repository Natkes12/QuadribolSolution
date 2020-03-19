using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadribolPresentationLayer.Models.Insert
{
    public class JogoInsertViewModel
    {
        public DateTime DataJogo { get; set; }
        public int PontuacaoTime1 { get; set; }
        public int PontuacaoTime2 { get; set; }
        public virtual Narrador Narrador { get; set; }
        public int NarradorID { get; set; }
        public bool Encerrado { get; set; }
    }
}
