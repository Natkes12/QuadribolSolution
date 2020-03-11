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
        public int ID { get; set; }
        public virtual List<Competidor> Competidor { get; set; }
        public Casa Casa { get; set; }
    }
}
