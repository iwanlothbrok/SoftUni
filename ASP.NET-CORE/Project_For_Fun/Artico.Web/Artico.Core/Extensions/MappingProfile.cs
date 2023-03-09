namespace Artico.Core.Extensions
{
	using Artico.Core.Models;
	using Artico.Infrastrucutre.Data.Models;
	using AutoMapper;

	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//mapping for books
			this.CreateMap<Article, ArticleFormModel>();
		}
	}
}
