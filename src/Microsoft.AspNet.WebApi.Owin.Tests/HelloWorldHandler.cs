using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.WebApi.Owin.Tests
{
    public class HelloWorldHandler : DelegatingHandler
    {
        public bool CtorOneCalled { get; set; }
        public bool CtorTwoCalled { get; set; }

        public HelloWorldHandler()
        {
            CtorOneCalled = true;
        }

        public HelloWorldHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            CtorTwoCalled = true;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
                               {
                                   RequestMessage = request,
                                   Content = new StringContent("Hello World", Encoding.UTF8, "text/plain")
                               };

            return Task.Factory.StartNew(() => response);
        }
    }
}