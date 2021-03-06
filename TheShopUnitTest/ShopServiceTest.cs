﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheShop;
using TheShop.Models.Suppliers;
using TheShop.Services;
using TheShop.Utility;

namespace TheShopUnitTest
{
    [TestClass]
    public class ShopServiceTest
    {
        ShopService shopService = new ShopService(new Logger());

        [TestMethod]
        public void OrderAndSellArticleTest()
        {
            try
            {
                shopService.OrderAndSellArticle(1, 459, 10);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void OrderAndSellArticleFailingTest()
        {
            try
            {
                shopService.OrderAndSellArticle(1, 20, 10);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Could not order article", ex.Message, true);
            }

        }

        [TestMethod]
        public void FindArticleTest()
        {
            Supplier1 supplier = new Supplier1();
            Article expected = new Article()
            {
                ID = 1,
                Name = "Article from supplier1",
                Price = 458
            };

            Article actual = shopService.FindArticle(supplier, 1, 458);
            var equals = actual.EqualsTo(expected);

            Assert.IsTrue(equals);
        }

        [TestMethod]
        public void FindArticleFailingTest()
        {

            Supplier1 supplier = new Supplier1();
            Article actual = shopService.FindArticle(supplier, 1, 20);
            Assert.AreEqual(null, actual);

        }


        [TestMethod]
        public void NoFindArticleTest()
        {
            try
            {
                Supplier1 supplier = new Supplier1();
                Article actual = shopService.FindArticle(supplier, 3, 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Could not find article with ID: 3", ex.Message, true);
            }

        }


        [TestMethod]
        public void GetByIdTest()
        {
            Article expected = new Article()
            {
                ID = 1,
                Name = "Article from supplier1",
                Price = 458,
                BuyerId = 10,
                IsSold = true,
                SoldDate = DateTime.Today
            };
            shopService.OrderAndSellArticle(1, 459, 10);
            Article actual = shopService.GetById(1);

            var equals = actual.EqualsTo(expected);

            Assert.IsTrue(equals);
        }

        [TestMethod]
        public void GetByIdFailingTest()
        {
            try
            {
                shopService.OrderAndSellArticle(1, 459, 10);
                Article article = shopService.GetById(12);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Could not find article with ID: 12", ex.Message, true);
            }
        }
    }
}
