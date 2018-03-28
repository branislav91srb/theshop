using TheShop.Base;

namespace TheShop.Models.Suppliers
{
    public class Supplier1 : ISupplier
    {
        public bool ArticleInInventory(int id) => true;

        public Article GetArticle(int id)
        {
            return new Article()
            {
                ID = id,
                Name = "Article from supplier1",
                Price = 458
            };
        }
    }
}
