using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class TimeCompetidor
    {
        public int TimeID { get; set; }
        public int CompetidorID { get; set; }
        public virtual Time Time { get; set; }
        public virtual Competidor Competidor { get; set; }
    }
}
