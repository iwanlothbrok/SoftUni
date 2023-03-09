namespace Watchlist.Extension
{
    using System.Security.Claims;

    public static class UserHelperExtension
    {
        public static string GetId(this ClaimsPrincipal user)
          => user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
