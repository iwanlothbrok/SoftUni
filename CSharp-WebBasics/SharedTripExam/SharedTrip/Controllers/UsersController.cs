using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IService userService;
        public UsersController(
            Request request,
            IService _service)
            : base(request)
        {
            userService = _service;
        }

        public Response Login()
            => View();
        public Response Register()
            => View();
    }
}
