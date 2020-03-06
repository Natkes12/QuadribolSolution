using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INarradorService
    {
        Task Insert(Narrador narrador);
        Task<List<Narrador>> GetNarrador();
    }
}
