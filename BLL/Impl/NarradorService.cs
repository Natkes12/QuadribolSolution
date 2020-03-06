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
                return await _narradorRepository.GetNarradores();
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }

        }
    }

       
    }
