using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadribolPresentationLayer.Models.Insert
{
    public class JogoTimeInsertViewModel
    {
        public virtual Time Time { get; set; }
        public virtual Jogo Jogo { get; set; }
    }
}
