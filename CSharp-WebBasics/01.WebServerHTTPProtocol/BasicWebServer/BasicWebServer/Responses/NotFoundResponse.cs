using BasicWebServer.Demo.HTTP;

namespace BasicWebServer.Demo.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse()
           : base(StatusCode.NotFound)
        {

        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! CHECK IF ITS THE RIGHT PLACE FOR THIS METHOD 
     

    }
}
