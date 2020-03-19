using DAO.Interfaces;
using Entity;
using Entity.Enums;
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

        public async Task<Time> GetByCasa(Casa casa)
        {
            Time time = new Time();

            try
            {
                time = await _context.Times.FirstAsync(c => c.Casa == casa);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Enumerator failed to MoveNextAsync."))
                {
                    return null;
                }
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }

            return time;
        }

        public async Task<Time> GetByID(int id)
        {
            Time time = new Time();

            try
            {
                time = await this._context.Times.FirstAsync(c => c.ID == id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }

            return time;
        }

        public async Task<DataResponse<Time>> GetTimes()
        {
            DataResponse<Time> response = new DataResponse<Time>();

            try
            {
                response.Data = _context.Times.Include(c => c.Competidores).ToListAsync();
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
