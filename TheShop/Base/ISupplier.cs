namespace TheShop.Base
{
    public interface ISupplier
    {
        bool ArticleInInventory(int id);

        Article GetArticle(int id);
    }
}
