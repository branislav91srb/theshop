using System;
using System.Collections.Generic;
using System.Linq;

namespace TheShop
{
	public class ShopService
	{
        private ArticleRepository _repository;
		private Logger _logger;
        private List<object> _suppliers;

        public ShopService()
		{
			_repository = new ArticleRepository();
			_logger = new Logger();
            _suppliers = new List<object>
            {
                new Supplier1(),
                new Supplier2(),
                new Supplier3()
            };
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
			#region ordering article

			Article article = null;
			Article tempArticle = null;
            List<Article> bestOfferArticles = new List<Article>();
            foreach (ISupplier supplier in _suppliers)
            {
                tempArticle = FindArticle(supplier, id, maxExpectedPrice);
                if(tempArticle!=null)
                    bestOfferArticles.Add(tempArticle);

            }

            tempArticle = bestOfferArticles.OrderBy(x => x.ArticlePrice).FirstOrDefault();

			
			article = tempArticle;
			#endregion

			#region selling article

			if (article == null)
			{
				throw new Exception("Could not order article");
			}

            _logger.Log(LogLevel.DEBUG, "Trying to sell article with id=" + id);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;
			
			try
			{
				_repository.Save(article);
                _logger.Log(LogLevel.INFO, "Article with id=" + id + " is sold.");
			}
			catch (ArgumentNullException ex)
			{
				_logger.Log(LogLevel.ERROR, "Could not save article with id=" + id);
				throw new Exception("Could not save article with id");
			}
			catch (Exception)
			{
			}

			#endregion
		}

        public Article FindArticle(ISupplier supplier, int id, int maxExpectedPrice)
        {
            if(supplier.ArticleInInventory(id))
            {
                try
                {
                    Article article = supplier.GetArticle(id);
                    if (article.ArticlePrice <= maxExpectedPrice)
                        return article;
                }
                catch (Exception ex)
                {
                    throw new Exception("Could not find article with ID: " + id);
                }

            }
            return null;
        }

        public Article GetById(int id)
		{
			return _repository.GetById(id);
		}
	}

  

    #region Supplier
    public interface ISupplier
    {
        bool ArticleInInventory(int id);
        Article GetArticle(int id);
    }

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

    public class Supplier2 : ISupplier
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
                ArticleName = "Article from supplier2",
                ArticlePrice = 459
            };
        }
    }

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
    #endregion

}
