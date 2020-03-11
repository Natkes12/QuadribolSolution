using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class Usuario
    {
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Nome { get; set; }
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(15)")]
        public string Senha { get; set; }
        public Permissao Permissao { get; set; }
        public bool EhAtivo { get; set; }
    }
}
