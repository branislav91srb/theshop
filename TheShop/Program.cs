using System;
using TheShop.Services;
using TheShop.Utility;

namespace TheShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var logger = new Logger();
            var shopService = new ShopService(logger);

            try
            {
                //order and sell
                shopService.OrderAndSellArticle(1, 20, 10);
                //shopService.OrderAndSellArticle(2, 459, 10);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.ERROR, ex.Message);
            }

            try
            {
                //print article on console
                var article = shopService.GetById(1);
                logger.Log(LogLevel.INFO, "Found article with ID: " + article.ID);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.WARN, "Article not found: " + ex.Message);
            }

            try
            {
                //print article on console				
                var article = shopService.GetById(12);
                logger.Log(LogLevel.INFO, "Found article with ID: " + article.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Article not found: " + ex);
                logger.Log(LogLevel.ERROR, "Article not found: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}