using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Permissao Permissao { get; set; }
        public bool EhAtivo { get; set; }
    }
}
