using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Time
    {
        public int ID { get; set; }
        public Competidor[] Competidor { get; set; }
        public Casa Casa { get; set; }

        public Time()
        {
            Competidor = new Competidor[7];
        }
    }
}
