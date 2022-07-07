using BasicWebServer.Demo.HTTP;
using BasicWebServer.Server.Common;
using System.Text;

namespace BasicWebServer.Demo.Responses
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType)
            : base(StatusCode.OK)
        {
            Guard.AgainsNull(content);
            Guard.AgainsNull(contentType);

            this.Headers.Add(Header.ContentType, contentType);

            this.Body = content;
        }

        public override string ToString()
        {
            if (this.Body != null)
            {
                var contentLenght = Encoding.UTF8.GetByteCount(this.Body).ToString();
                this.Headers.Add(Header.ContentLenght, contentLenght);
            }
            return base.ToString();
        }


    }
}
