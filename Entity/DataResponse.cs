using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class DataResponse<T> : Response
    {
        public List<T> Data { get; set; }
    }
}
