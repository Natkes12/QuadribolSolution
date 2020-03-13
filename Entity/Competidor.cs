using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("COMPETIDORES")]
    public class Competidor
    {
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Nome { get; set; }
        public Casa Casa { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Funcao Funcao { get; set; }
        public bool Disponivel { get; set; }
        public bool EhAtivo { get; set; }

    }

}
