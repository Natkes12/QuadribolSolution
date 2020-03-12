using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class TimeCompetidor
    {
        public virtual Time Time { get; set; }
        public virtual Competidor Competidor { get; set; }
        public int TimeID { get; set; }
        public int CompetidorID { get; set; }
    }
}
