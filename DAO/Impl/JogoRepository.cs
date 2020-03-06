using DAO.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class JogoRepository : IJogoRepository
    {
        private readonly QuadribolContext _context;

        public JogoRepository(QuadribolContext context)
        {
            this._context = context;
        }

        public async Task<DataResponse<Jogo>> GetJogos()
        {
            DataResponse<Jogo> response = new DataResponse<Jogo>();

            try
            {
                response.Data = _context.Jogos.ToListAsync();
                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Erros.Add("Erro no banco de dados.");
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
            }

            return response;
        }

        public async Task<Response> Insert(Jogo jogo)
        {
            Response response = new Response();

            try
            {
                this._context.Jogos.Add(jogo);
                await this._context.SaveChangesAsync();
                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Erros.Add("Erro no banco de dados.");
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
            }

            return response;
        }
    }
}
