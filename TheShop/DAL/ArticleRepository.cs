using System;
using System.Collections.Generic;
using System.Linq;


namespace TheShop
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly IList<Article> _articles = new List<Article>();

        public IList<Article> GetAll()
        {
            return _articles;
        }

        public Article GetById(int id)
        {
            try
            {
                return _articles.Single(x => x.ID == id);
            }
            catch
            {
                throw new Exception("Could not find article with ID: " + id);
            }
        }

        public void Remove(Article entity)
        {
            _articles.Remove(entity);
        }

        public void Save(Article entity)
        {
            _articles.Add(entity);
        }
    }
}
