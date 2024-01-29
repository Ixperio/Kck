using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DB;
using DB.Entities;
using Logic.Repos.Intrefaces;

namespace Logic.Repos.DbImplementations
{
    public class DbArticleRepository : IArticleRepository
    {
        private readonly MyDbContext _context;

        public DbArticleRepository(MyDbContext context)
        {
            _context = context;
        }

        public int Add(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            return article.Id;
           
        }
        public bool Delete(int id)
        {
            var article = _context.Articles.SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
            if(article is null) { return false; }
            article.IsDeleted = true;
            _context.Articles.Update(article);
            _context.SaveChanges();
            return true;
        }
        public Article GetOne(int id)
        {
            var article = _context.Articles.SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
            if(article is null) { return null; }
            return article;
        }
        public List<Article> GetAll()
        {
            return _context.Articles.Where(x => x.IsDeleted == false).ToList();
        }

        public List<Article> GetBest()
        {
            return this.GetAll();
        }
        public List<Article> GetNewest()
        {
            return this.GetAll().OrderByDescending(x => x.CreationDate).Take(3).ToList();
        }
        public List<Article> GetAllByIds(List<int> ids)
        {
            return _context.Articles.Where(x => x.IsDeleted == false).Where(x =>ids.Contains(x.Id)).ToList();
        }

        public bool Update(Article article)
        {
           Article art = this.GetOne(article.Id);
            if(art is null) { return false; }
            _context.Articles.Update(article);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateViews(int id)
        {
            Article art = this.GetOne(id);
            if (art is null) { return false; }
            art.Viewers = art.Viewers + 1;
            _context.Articles.Update(art);
            _context.SaveChanges();
            return true;
        }
    }
}
