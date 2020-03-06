using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITimeService
    {
        Task Insert(Time time);
        Task<List<Time>> GetTimes();
    }
}
