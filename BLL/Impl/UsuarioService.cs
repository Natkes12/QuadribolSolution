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
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public async Task<Response> Insert(Usuario usuario)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                response.Erros.Add("O nome do usuário deve ser informado.");
            }

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            try
            {
                await _usuarioRepository.Insert(usuario);
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

        public async Task<DataResponse<Usuario>> GetUsuarios()
        {
            List<Usuario> usuario = new List<Usuario>();
            DataResponse<Usuario> response = new DataResponse<Usuario>();

            if (usuario.Count <= 0)
            {
                response.Erros.Add("Nenhum usuário adicionado!");
                response.Sucesso = false;
                return response;
            }
            try
            {
                return await _usuarioRepository.GetUsuarios();
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
