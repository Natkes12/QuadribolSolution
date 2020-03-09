using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadribolPresentationLayer.Models.Insert
{
    public class JogoInsertViewModel
    {
        public int Time1ID { get; set; }
        public int Time2ID { get; set; }
        public DateTime DataJogo { get; set; }
        public int Pontuacao { get; set; }
        public int NarradorID { get; set; }
    }
}
