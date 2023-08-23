using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.dll.Contract
{
    public interface IUserContext
    {
        Task<HttpResponseMessage> SendGetRequestAsync(string url, int size = 2);
        Task<HttpResponseMessage> SendGetRequestBySizeAsync(string url,int size = 2);
    }
}
