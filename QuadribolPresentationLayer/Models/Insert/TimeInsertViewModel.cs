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
        public Casa Casa { get; set; }
        public Competidor Artilheiro1 { get; set; }
        public Competidor Artilheiro2 { get; set; }
        public Competidor Artilheiro3 { get; set; }
        public Competidor Batedor1 { get; set; }
        public Competidor Batedor2 { get; set; }
        public Competidor Apanhador { get; set; }
        public Competidor Goleiro { get; set; }
    }
}
