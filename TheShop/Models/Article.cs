using System;
using TheShop.Base;

namespace TheShop
{
    public class Article : EntityBase
    {
        public string ArticleName { get; set; }

        public int ArticlePrice { get; set; }
        public bool IsSold { get; set; }

        public DateTime SoldDate { get; set; }
        public int BuyerUserId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Article other)
            {
                return Equals(other.ID, ID) && Equals(other.ArticleName, ArticleName)
                     && Equals(other.ArticlePrice, ArticlePrice);
            }
            return false;
        }
    }
}
