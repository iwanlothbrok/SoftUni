using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateRole()
        {
           await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Administrator"
            });

            return Ok();
        }

    }
}
