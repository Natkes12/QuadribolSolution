﻿using BLL.Interfaces;
using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class JogoTimeService : IJogoTimeService
    {
        private IJogoTimeRepository _jogoTimeRepository;

        public JogoTimeService(IJogoTimeRepository jogoTimeRepository)
        {
            this._jogoTimeRepository = jogoTimeRepository;
        }

        public async Task<Response> Delete(JogoTime jogoTime)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<JogoTime>> GetData()
        {
            return await _jogoTimeRepository.GetData();
        }

        public async Task<Response> Insert(JogoTime jogoTime)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                await _jogoTimeRepository.Insert(jogoTime);
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

        public async Task<Response> Update(JogoTime jogoTime)
        {
            throw new NotImplementedException();
        }
    }
}
