using DAO.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private QuadribolContext _context;

        public UsuarioRepository(QuadribolContext context)
        {
            this._context = context;
        }
        public async Task<Usuario> Autenticar(string email, string senha)
        {
            Response response = new Response();
            Usuario user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (user == null)
            {
                return null;
            }
            else if (user.EhAtivo == false)
            {
                return null;
            }
            return user;
        }

        public async Task<Response> Delete(Usuario usuario)
        {
            Response response = new Response();

            usuario.EhAtivo = false;

            try
            {
                this._context.Usuarios.Update(usuario);
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

        public async Task<Usuario> GetUsuario(int id)
        {
            Usuario user = await _context.Usuarios.FirstOrDefaultAsync(u => u.ID == id);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            return user;
        }

        public async Task<DataResponse<Usuario>> GetUsuarios()
        {
            DataResponse<Usuario> response = new DataResponse<Usuario>();

            try
            {
                response.Data = _context.Usuarios.ToListAsync();
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

        public async Task<Response> Insert(Usuario usuario)
        {
            Response response = new Response();

            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                response.Sucesso = true;
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("UQ"))
                {
                    response.Erros.Add("Usuário já existente");
                }
                else
                {
                    response.Erros.Add("Erro no banco de dados.");
                }
                response.Sucesso = false;
            }

            return response;
        }

        public async Task<Response> Update(Usuario usuario)
        {
            Response response = new Response();

            try
            {
                this._context.Usuarios.Update(usuario);
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
