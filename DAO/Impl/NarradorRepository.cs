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
    public class NarradorRepository : INarradorRepository
    {
        private readonly QuadribolContext _context;

        public NarradorRepository(QuadribolContext context)
        {
            this._context = context;
        }

        public async Task<DataResponse<Narrador>> GetNarradores()
        {
            DataResponse<Narrador> response = new DataResponse<Narrador>();

            try
            {
                response.Data = _context.Narradores.ToListAsync();
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

        public async Task<Response> Insert(Narrador narrador)
        {
            Response response = new Response();

            try
            {

                this._context.Narradores.Add(narrador);
                await this._context.SaveChangesAsync();
                response.Sucesso = true;

            }
            catch (Exception ex)
            {
                response.Erros.Add("Erro no banco de dados.");
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
            }

            return response;
        }
    }
}
