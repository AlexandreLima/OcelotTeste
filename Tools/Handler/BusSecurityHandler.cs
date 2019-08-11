using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ocelotteste.Tools.Handler
{
    public class BusSecurtityHandler : DelegatingHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BusSecurtityHandler(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient("barramento");
            return client.SendAsync(request, cancellationToken);
        }
    }
}