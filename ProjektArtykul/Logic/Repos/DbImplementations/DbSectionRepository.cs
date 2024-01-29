using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DB;
using DB.Entities;
using Logic.Repos.Intrefaces;

namespace Logic.Repos.DbImplementations
{
    public class DbSectionRepository : ISectionRepository
    {
        private readonly MyDbContext _context;

        public DbSectionRepository(MyDbContext context)
        {
            _context = context;
        }

        public long Add(ArticleSections articles)
        {
            _context.ArticleSections.Add(articles);
            _context.SaveChanges();
            return articles.Id;
        }
        public bool Delete(long id)
        {
            var tag = _context.ArticleSections.SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
            if(tag is null) { return false; }
            tag.IsDeleted = true;
            _context.SaveChanges();
            return true;
        }
        public ArticleSections GetSectionById(long sectionId)
        {
           return _context.ArticleSections.Where(x => x.Id == sectionId && x.IsDeleted == false).SingleOrDefault();
        }
        public List<ArticleSections> GetAllByArticleId(int id)
        {
          
            return _context.ArticleSections.Where(x => x.articleId == id && x.IsDeleted == false).ToList();
        }

        public bool Update(ArticleSections articles)
        {
            if(this.GetSectionById(articles.Id) != null) {
                _context.ArticleSections.Update(articles);
                _context.SaveChanges();
                return true;
                }
            return false;
        }
    }
}
