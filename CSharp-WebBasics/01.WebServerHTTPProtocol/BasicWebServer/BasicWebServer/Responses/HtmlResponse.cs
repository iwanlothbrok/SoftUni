using BasicWebServer.Demo.HTTP;

namespace BasicWebServer.Demo.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text)
            : base(text,ContentType.Html)
        {

        }
    }
}
