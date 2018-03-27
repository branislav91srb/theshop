using TheShop.Base;

namespace TheShop.Models.Suppliers
{
    public class Supplier1 : ISupplier
    {
        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public Article GetArticle(int id)
        {
            return new Article()
            {
                ID = 1,
                ArticleName = "Article from supplier1",
                ArticlePrice = 458
            };
        }
    }
}
