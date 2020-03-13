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
    public class TimeRepository : ITimeRepository
    {
        private readonly QuadribolContext _context;

        public TimeRepository(QuadribolContext context)
        {
            this._context = context;
        }

        public async Task<DataResponse<Time>> GetTimes()
        {
            DataResponse<Time> response = new DataResponse<Time>();

            try
            {
                response.Data = _context.Times.ToListAsync();
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

        public async Task<Response> Insert(Time time)
        {
            Response response = new Response();

            try
            {
                this._context.Times.Add(time);
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
