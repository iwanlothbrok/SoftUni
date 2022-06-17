
using ProductShop.Models;

namespace ProductShop.Dtos
{
    public class CategoriesProductsDto
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
