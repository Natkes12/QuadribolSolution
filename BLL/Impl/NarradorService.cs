using BLL.Interfaces;
using DAO;
using DAO.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class NarradorService : INarradorService
    {
        private INarradorRepository _narradorRepository;

        public NarradorService(INarradorRepository narradorRepository)
        {
            this._narradorRepository = narradorRepository;
        }
        public async Task<Response> Insert(Narrador narrador)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(narrador.Nome))
            {
                response.Erros.Add("O nome do narrador deve ser informado.");
            }
            else if(narrador.Nome.Length < 2 || narrador.Nome.Length > 50)
            {
                response.Erros.Add("O nome do narrador deve conyter entre 2 e 50 caracteres.");
            }

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                await _narradorRepository.Insert(narrador);
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

        public async Task<DataResponse<Narrador>> GetNarrador()
        {
            try
            {
                return await _narradorRepository.GetNarradores();
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }

        }

        public Task<Response> Update(Narrador narrador)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Delete(Narrador narrador)
        {
            throw new NotImplementedException();
        }
    }

       
    }
