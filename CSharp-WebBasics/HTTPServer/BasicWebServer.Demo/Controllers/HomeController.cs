using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BasicWebServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
            Name: <input type='text' name='Name'/>
            Age: <input type='number' name ='Age'/>
            <input type='submit' value ='Save' />
        </form>";
        private const string DownloadForm = @"<form action='/Content' method='POST'>
                <input type='submit' value ='Download Sites Content' /> 
            </form>";
        private const string FileName = "content.txt";


        public HomeController(Request request)
            : base(request)
        {

        }
        public Response Index() => Text("Hello from my server!");
        public Response Redirect() => Redirect("https://softuni.org/");
        public Response Html() => View();
        public Response HtmlPostForm()
        {
            string formData = string.Empty;
            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }
            return Text(formData);
        }
        public Response Content() =>View();
        public Response Cookies()
        {

            if (Request.Cookies.Any(c => c.Name != BasicWebServer.Server.HTTP.Session.SessionCookieName))
            {
                var cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText
                    .Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table>");


                return Html(cookieText.ToString());
            }
            var cookies = new CookieCollection();
            cookies.Add("FirstTry-HackingYourPhone", "Hacked");
            cookies.Add("FirstTry-HackingYourComputer", "Hacked");

            return Html("<h1>Software is hacked!</h1>",cookies);
        }

        public Response Session()
        {
            var currentDateKey = "CurrentDate!";
            var sessionExist = Request.Session.ContainsKey(currentDateKey);
            if (sessionExist )
            {
                var currentDate = this.Request.Session[currentDateKey];
                return Text($"Stored date: {currentDate}");

            }
            return Text($"Current stored date!");
        }
    }
}
