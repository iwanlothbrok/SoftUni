namespace Artico.Core.Extensions
{
	using System.Security.Claims;

	public static class ClaimsPrincipalExtension
	{
		public static string GetId(this ClaimsPrincipal user)
						=> user.FindFirst(ClaimTypes.NameIdentifier).Value;
	}
}
