using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Response
    {
        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }

        public Response()
        {
            this.Erros = new List<string>();
        }

        public bool HasErrors()
        {
            return this.Erros.Count > 0;
        }

        public string GetErrorMessage()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string item in this.Erros)
            {
                builder.AppendLine(item);
            }

            return builder.ToString();
        }
    }
}
