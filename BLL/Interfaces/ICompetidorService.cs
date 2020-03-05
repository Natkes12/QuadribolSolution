using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompetidorService
    {
       Task Insert(Competidor competidor);
       Task<List<Competidor>> GetCompetidores();
    }
}
