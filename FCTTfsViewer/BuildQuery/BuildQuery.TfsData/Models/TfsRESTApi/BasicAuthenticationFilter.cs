using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models.TfsRESTApi
{
    
    public interface IHttpRequestHeaderFilter
    {
        HttpRequestHeaders ProcessHeaders(HttpRequestHeaders headers);
    }

    public class BasicAuthenticationFilter : IHttpRequestHeaderFilter
    {
        private string _authToken;

        public BasicAuthenticationFilter(NetworkCredential userCredential)
        {
            var userPass = string.Format("{0}:{1}", userCredential.Domain +"\\" + userCredential.UserName, userCredential.Password);
            _authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes(userPass));
        }

        public HttpRequestHeaders ProcessHeaders(HttpRequestHeaders headers)
        {
            headers.Authorization = new AuthenticationHeaderValue("Basic", _authToken);
            return headers;
        }
    }

}
