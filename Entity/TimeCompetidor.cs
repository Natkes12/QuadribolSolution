using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    [Table("TIME_COMPETIDOR")]
    public class TimeCompetidor
    {
        public int TimeID { get; set; }
        public int CompetidorID { get; set; }
        public virtual Time Time { get; set; }
        public virtual Competidor Competidor { get; set; }
    }
}
