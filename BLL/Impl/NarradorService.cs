using BLL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class NarradorService : INarradorService
    {
        public Task Insert(Narrador narrador)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(narrador.Nome))
            {
                response.Erros.Add("O nome do narrador deve ser informado.");
            }

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                using (QuadribolContext db = new QuadribolContext())
                {
                    db.Competidores.Add(item);
                    db.SaveChanges();
                }
                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Erros.Add("Erro no banco de dados, contate o administrador.");
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                return response;
            }
        }

        public Task<List<Narrador>> GetNarrador()
        {
            List<Narrador> narrador = new List<Narrador>();
            DataResponse<Narrador> response = new DataResponse<Narrador>();

            if (narrador.Count <= 0)
            {
                response.Erros.Add("Nenhum narrador adicionado!");
                response.Sucesso = false;
                return response;
            }
            try
            {
                using (QuadribolContext context = new QuadribolContext())
                {
                    return await context.Competidores.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }

        }
    }

       
    }
}
