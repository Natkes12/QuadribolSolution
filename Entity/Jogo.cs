﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    [Table("JOGOS")]
    public class Jogo
    {
        public int ID { get; set; }
        public virtual Time Time1 { get; set; }
        public int Time1ID { get; set; }
        public virtual Time Time2 { get; set; }
        public int Time2ID { get; set; }
        [Required]
        [Column(TypeName = "DATETIME2")]
        public DateTime DataJogo { get; set; }
        public int Pontuacao { get; set; }
        public virtual Narrador Narrador { get; set; }
        public int NarradorID { get; set; }
        public bool Encerrado { get; set; }
    }
}
