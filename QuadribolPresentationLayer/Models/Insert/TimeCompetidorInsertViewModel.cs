using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadribolPresentationLayer.Models.Insert
{
    public class TimeCompetidorInsertViewModel
    {
        public virtual Time Time { get; set; }
        public virtual Competidor Competidor { get; set; }
    }
}
