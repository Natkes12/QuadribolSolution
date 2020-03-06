using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DataResponse<T> : Response
    {
        public Task<List<T>> Data { get; set; }
    }
}
