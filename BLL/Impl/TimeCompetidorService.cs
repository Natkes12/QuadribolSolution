using BLL.Interfaces;
using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class TimeCompetidorService : ITimeCompetidorService
    {
        private ITimeCompetidorRepository _timeCompetidorRepository;

        public TimeCompetidorService(ITimeCompetidorRepository timeCompetidorRepository)
        {
            this._timeCompetidorRepository = timeCompetidorRepository;
        }

        public async Task<Response> Insert(TimeCompetidor timeCompetidor)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                await _timeCompetidorRepository.Insert(timeCompetidor);
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

        public async Task<Response> Update(TimeCompetidor timeCompetidor)
        {
            throw new NotImplementedException();
        }
        public async Task<Response> Delete(TimeCompetidor timeCompetidor)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<TimeCompetidor>> GetData()
        {
            return await _timeCompetidorRepository.GetData();
        }

       
    }
}
