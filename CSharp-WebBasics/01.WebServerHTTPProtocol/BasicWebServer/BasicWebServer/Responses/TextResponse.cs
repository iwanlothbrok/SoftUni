using BasicWebServer.Demo.HTTP;

namespace BasicWebServer.Demo.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
        : base(text, ContentType.PlaintText)
        {

        }
    }
}
    