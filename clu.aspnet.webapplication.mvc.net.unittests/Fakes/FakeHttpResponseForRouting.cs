using System.Web;

namespace clu.aspnet.webapplication.mvc.net.unittests.Fakes
{
    internal class FakeHttpResponseForRouting : HttpResponseBase
    {
        public override string ApplyAppPathModifier(string virtualPath)
        {
            return virtualPath;
        }
    }
}