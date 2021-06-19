using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Response <T>
    {
        public Response()
        {

        }
        public Response(T response)
        {

        }

        public T Data { get; set; }
    }
}
