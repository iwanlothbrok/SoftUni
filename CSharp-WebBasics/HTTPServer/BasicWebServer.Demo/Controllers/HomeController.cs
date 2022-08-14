using BasicWebServer.Demo.Models;
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System.Linq;
using System.Text;
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
        [HttpPost]
        public Response HtmlPostForm()
        {
            string name = Request.Form["Name"];
            string age = Request.Form["Age"];

            var model = new FormViewModel()
            {
                Name = name,
                Age = int.Parse(age)
            };

            return View(model);
        }
        public Response Content() => View();
        public Response DownloadContent() => File(FileName);//make it work
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
            var sessionExists = Request.Session
                .ContainsKey(Server.HTTP.Session.SessionCurrentDateKey);

            var bodyText = "";

            if (sessionExists)
            {
                var currentDate = Request.Session[Server.HTTP.Session.SessionCurrentDateKey];
                bodyText = $"Stored date: {currentDate}!";
            }
            else
            {
                bodyText = "Current date stored!";
            }

            return Text(bodyText);
        }
    }
}
