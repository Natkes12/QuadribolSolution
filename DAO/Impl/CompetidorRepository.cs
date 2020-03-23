using DAO.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CompetidorRepository : ICompetidorRepository
    {
        private readonly QuadribolContext _context;

        public CompetidorRepository(QuadribolContext context)
        {
            this._context = context;
        }

        public async Task<Response> DesalocarTime(Competidor competidor)
        {
            Response response = new Response();

            competidor.Time = null;
            competidor.TimeID = null;

            try
            {
                this._context.Competidores.Update(competidor);
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

        public async Task<Competidor> GetByID(int id)
        {
            Competidor competidor = new Competidor();

            try
            {
                competidor = await _context.Competidores.FirstAsync(c => c.ID == id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }

            return competidor;
        }

        public async Task<DataResponse<Competidor>> GetCompetidores()
        {
            DataResponse<Competidor> response = new DataResponse<Competidor>();

            try
            {
                response.Data = _context.Competidores.ToListAsync();
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

        public async Task<Response> Insert(Competidor competidor)
        {
            Response response = new Response();

            try
            {
                this._context.Competidores.Add(competidor);
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

        public async Task<Response> Update(Competidor competidor)
        {
            Response response = new Response();

            try
            {
                Competidor competidorSelecionado = competidor;
                this._context.Competidores.Update(competidorSelecionado);
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
