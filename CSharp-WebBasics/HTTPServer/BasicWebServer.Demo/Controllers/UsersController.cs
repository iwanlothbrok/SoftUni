using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        private const string LoginForm = @"<form action='/Login' method='POST'>
                Username: <input type='text' name='Username'/>
                Password: <input type='password' name='Password'/>
                <input type='submit' value ='Log In' /> 
            </form>";
        private const string Username = "user";

        private const string Password = "user123";
        public UsersController(Request request) : base(request)
        {
        }

        public Response Login() => View();
        public Response LogInUser()
        {
            this.Request.Session.Clear();

            var usernameMatches =
                this.Request.Form["Username"] == UsersController.Username;
            var passwordMatches =
             this.Request.Form["Password"] == UsersController.Password;

            if (usernameMatches && passwordMatches)
            {
                if (!Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";
                    var cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName, Request.Session.Id);

                    return Html("<h3>Logged succesfully!</h3>", cookies);
                }
                return Html("<h3>Logged succesfully!</h3>");
            }
            return Redirect("/Login");
        }

        public Response Logout()
        {
            Request.Session.Clear();

            return Html($"<h2>Logout successfully!");
        }

        public Response GetUserData()
        {
            if (this.Request.Session.ContainsKey(Session.SessionUserKey))
            {
                return Html($"<h3>Currently logged-in user is " +
                    $"with username '{Username}'</h3>");
            }
            return Redirect("/Login");
        }

    }
}
