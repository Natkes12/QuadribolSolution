using Entity;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadribolPresentationLayer.Models.Insert
{
    public class TimeInsertViewModel
    {
        public virtual Time Time { get; set; }
        public virtual Competidor Competidor { get; set; }
    }
}
