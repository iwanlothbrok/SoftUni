    
using BasicWebServer.Demo.Responses;
using System;
using System.Text;

namespace BasicWebServer.Demo.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;

            Headers.Add(Header.Server, "My Web Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:R}");
        }

        public StatusCode StatusCode { get; set; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            result.AppendLine();

            if (!string.IsNullOrEmpty(this.Body))
            {
                result.Append(Body);
            }

            return result.ToString().TrimEnd();
        }

    }
}
