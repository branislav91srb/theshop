using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class Article
    {
        public int ID { get; set; }
        public string ArticleName { get; set; }

        public int ArticlePrice { get; set; }
        public bool IsSold { get; set; }

        public DateTime SoldDate { get; set; }
        public int BuyerUserId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Article)
            {
                Article other = (Article)obj;
                return Equals(other.ID, this.ID) && Equals(other.ArticleName, this.ArticleName)
                     && Equals(other.ArticlePrice, this.ArticlePrice);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
