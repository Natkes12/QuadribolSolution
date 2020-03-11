using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Response> Insert(Usuario usuario);
        Task<Usuario> Autenticar(string email, string senha);
        Task<Usuario> GetUsuario(int id);
    }
}
