using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Base;

namespace TheShop.Models.Suppliers
{
    public class Supplier3 : ISupplier
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
                ArticleName = "Article from supplier3",
                ArticlePrice = 460
            };
        }
    }
}
