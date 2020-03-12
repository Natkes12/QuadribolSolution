using Entity;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadribolPresentationLayer.Models.Query
{
    public class TimeQueryViewModel
    {
        public virtual Time Time { get; set; }
        public virtual Competidor Competidor { get; set; }
    }
}
