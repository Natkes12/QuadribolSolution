using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    [Table("JOGO_TIME")]
    public class JogoTime
    {
        public int TimeID { get; set; }
        public int JogoID { get; set; }
        public virtual Time Time { get; set; }
        public virtual Jogo Jogo { get; set; }
    }
}
