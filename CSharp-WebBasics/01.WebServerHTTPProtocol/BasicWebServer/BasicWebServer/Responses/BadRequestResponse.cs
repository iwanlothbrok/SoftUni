using BasicWebServer.Demo.HTTP;

namespace BasicWebServer.Demo.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse()
            :base(StatusCode.BadRequest)
        {

        }
    }
}
