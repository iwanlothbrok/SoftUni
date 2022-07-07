using BasicWebServer.Demo.HTTP;

namespace BasicWebServer.Demo.Responses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse()
           : base(StatusCode.Unauthorized)
        {

        }
    }
}
