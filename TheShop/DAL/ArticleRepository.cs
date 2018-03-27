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
            return _articles.ToList();
        }

        public Article GetById(object id)
        {
            try
            {
                return _articles.Where(x => x.ID == (int)id).Single();
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
