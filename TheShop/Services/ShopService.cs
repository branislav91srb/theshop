using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Base;
using TheShop.Models.Suppliers;
using TheShop.Utility;

namespace TheShop.Services
{
    public class ShopService
    {
        private ArticleRepository _repository;
        private Logger _logger;

        public ShopService(Logger logger)
        {
            _repository = new ArticleRepository();
            _logger = logger;
        }

        public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            var article = OrderArticle(id, maxExpectedPrice);

            SellArticle(article, id, buyerId);
        }

        private Article OrderArticle(int id, int maxExpectedPrice)
        {
            List<Article> bestOfferArticles = new List<Article>();

            foreach (ISupplier supplier in SupplierFactory.GetAll())
            {
                var article = FindArticle(supplier, id, maxExpectedPrice);

                if (article != null)
                {
                    bestOfferArticles.Add(article);
                }
            }

            return bestOfferArticles.OrderBy(x => x.ArticlePrice).FirstOrDefault();
        }

        private void SellArticle(Article article, int id, int buyerId)
        {
            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            _logger.Log(LogLevel.DEBUG, "Trying to sell article with id=" + id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            _repository.Save(article);
            _logger.Log(LogLevel.INFO, "Article with id=" + id + " is sold.");
        }

        public Article FindArticle(ISupplier supplier, int id, int maxExpectedPrice)
        {
            if (supplier.ArticleInInventory(id))
            {
                Article article = supplier.GetArticle(id);

                if (article.ArticlePrice <= maxExpectedPrice)
                {
                    return article;
                }
            }
            return null;
        }

        public Article GetById(int id)
        {
            return _repository.GetById(id);
        }
    }

}
