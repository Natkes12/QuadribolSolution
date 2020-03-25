using BLL.Interfaces;
using DAO.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            Response response = new Response();
            Usuario usuario = new Usuario();

            try
            {
                usuario = await _usuarioRepository.Autenticar(email, senha);

                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Erros.Add("Erro no banco de dados, contate o administrador.");
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }

            return usuario;

        }

        public async Task<Response> Delete(Usuario usuario)
        {
            Response response = new Response();

            try
            {
                return await this._usuarioRepository.Delete(usuario);
            }
            catch (Exception ex)
            {
                response.Erros.Add("Erro no banco de dados, contate o administrador.");
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                return response;
            }
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            try
            {
                return await _usuarioRepository.GetUsuario(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task<DataResponse<Usuario>> GetUsuarios()
        {
            try
            {
                return await _usuarioRepository.GetUsuarios();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<Response> Insert(Usuario usuario)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                response.Erros.Add("O nome do usuário deve ser informado!");
            }
            else if (usuario.Nome.Length < 2 || usuario.Nome.Length > 50)
            {
                response.Erros.Add("O nome do usuário deve conter entre 2 e 50 caracteres!");
            }

            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                response.Erros.Add("A senha do usuário deve ser informado!");
            }
            if (usuario.Senha.Length < 2 || usuario.Senha.Length > 15)
            {
                response.Erros.Add("A senha do usuário deve conter entre 2 e 15 caracteres!");
            }

            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                response.Erros.Add("O email deve ser informado!");
            }
            else
            {
                usuario.Email = usuario.Email.Trim();
                usuario.Email = Regex.Replace(usuario.Email, @"\s+", " ");
                if (usuario.Email.Length < 10 || usuario.Email.Length > 50)
                {
                    response.Erros.Add("O email do cliente deve conter entre 10 e 50 caracteres");
                }
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

        public async Task<Response> Update(Usuario usuario)
        {
            Response response = new Response();

            try
            {
                return await this._usuarioRepository.Update(usuario);
            }
            catch(Exception ex)
            {
                response.Erros.Add("Erro no banco de dados, contate o administrador.");
                response.Sucesso = false;
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                return response;
            }
        }
    }
}
