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

            SellArticle(article, buyerId);
        }

        /// <summary>
        /// Search for article in all suppliers if exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="maxExpectedPrice"></param>
        /// <returns>Article with lowest price or null</returns>
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

            return bestOfferArticles.OrderBy(x => x.Price).FirstOrDefault();
        }

        private void SellArticle(Article article, int buyerId)
        {
            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            _logger.Log(LogLevel.DEBUG, "Trying to sell article with id=" + article.ID);

            article.IsSold = true;
            article.SoldDate = DateTime.Today;
            article.BuyerId = buyerId;

            _repository.Save(article);
            _logger.Log(LogLevel.INFO, "Article with id=" + article.ID + " is sold.");
        }

        public Article FindArticle(ISupplier supplier, int id, int maxExpectedPrice)
        {
            if (supplier.ArticleInInventory(id))
            {
                var article = supplier.GetArticle(id);

                if (article.Price <= maxExpectedPrice)
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
