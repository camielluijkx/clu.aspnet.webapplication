using System.Web;

namespace clu.aspnet.webapplication.mvc.net.unittests.Fakes
{
    internal class FakeHttpContextForRouting : HttpContextBase
    {
        FakeHttpRequestForRouting _request;
        FakeHttpResponseForRouting _response;

        public FakeHttpContextForRouting(string appPath = "/", string requestUrl = "~/")
        {
            _request = new FakeHttpRequestForRouting(appPath, requestUrl);
            _response = new FakeHttpResponseForRouting();
        }

        public override HttpRequestBase Request
        {
            get { return _request; }
        }

        public override HttpResponseBase Response
        {
            get { return _response; }
        }
    }
}