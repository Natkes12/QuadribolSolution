using BLL.Impl;
using BLL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class CompetidorService : ICompetidorService
    {
        public Task Insert(Competidor competidor)
        {
            Response response = new Response();

            if (competidor.Escolaridade < 4)
            {
                response.Erros.Add("O competidor deve ter escolaridade de no mínimo 4.");
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
        public Task<List<Competidor>> GetCompetidores()
        {
            List<Competidor> competidor = new List<Competidor>();
            DataResponse<Competidor> response = new DataResponse<Competidor>();

            if (competidor <= 0)
            {
                response.Erros.Add("Nenhum competidor adicionado!");
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
