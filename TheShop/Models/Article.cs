using System;
using TheShop.Base;

namespace TheShop
{
    public class Article : EntityBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsSold { get; set; }

        public DateTime SoldDate { get; set; }

        public int BuyerId { get; set; }
    }
}
