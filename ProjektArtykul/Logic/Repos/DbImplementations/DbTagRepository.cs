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
    public class DbTagRepository : ITagRepository
    {
        private readonly MyDbContext _context;

        public DbTagRepository(MyDbContext context)
        {
            _context = context;
        }

        public int Add(Tag tag)
        {
            tag.Id = _context.Tags.Max(x => (int?)x.Id).GetValueOrDefault(0) + 1;
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag.Id;
        }
        public bool Delete(int id)
        {
            var tag = _context.Tags.SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
            if(tag is null) { return false; }
            tag.IsDeleted = true;
            _context.Tags.Update(tag);
            _context.SaveChanges();
            return true;
        }
        public Tag GetTag(int id)
        {
            var tag = _context.Tags.SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
            if(tag is null) { return null; }
            return tag;
        }
        public List<Tag> GetAll()
        {
            return _context.Tags.Where(x => x.IsDeleted == false).ToList();
        }

        public List<Tag> GetAllByIds(List<int> ids)
        {
            return _context.Tags.Where(x => x.IsDeleted == false && ids.Contains(x.Id)).ToList();
        }
        public List<Tag> GetTagsByName(string name)
        {
            var Tag = _context.Tags.Where(x=> x.IsDeleted == false).Where(x => name.Contains(x.Name)).ToList();
            if (!Tag.Any()) { return null; }
            return Tag;
        }
        public List<Tag> GetAllByArticleId(int id)
        {
            var Tags = _context.ArticleTags.Where(x=>x.ArticleId == id).ToList();
            var ints = new List<int>();
            int va;
            foreach (var Tag in Tags)
            {
                va = Tag.TagId;
                ints.Add(va);
            }

            return this.GetAllByIds(ints);
        }
        public bool Update(Tag tag)
        {
            if (this.GetTag(tag.Id) != null)
            {
                _context.Tags.Update(tag);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<ArticleTags> GetTagByArticleId(int articleId) //zwraca pełną listę tagów-artykułów pod id artykuyłu
        {
            var articleTags = new List<ArticleTags>();
            articleTags = _context.ArticleTags.Where(x => x.ArticleId == articleId).ToList();
            return articleTags;
        }
        public List<ArticleTags> GetArticleByTagId(int tagId) //zwraca listę tagów-artykułów po id tagu
        {
            var articleTags = new List<ArticleTags>();
            articleTags = _context.ArticleTags.Where(x => x.TagId == tagId).ToList();
            return articleTags;
        }
        public ArticleTags GetArticleTagById(int id) //pobiera articleTag przy użyciu głównego id
        {
            var articleTags = new ArticleTags();
            articleTags = _context.ArticleTags.Where(x => x.Id == id).SingleOrDefault();
            if (articleTags != null) { return null; }
            return articleTags;
        }
        public bool DeleteArticleTag(int id) //zwraca tak jak usunie , oraz nie jak nie usunie
        {
            if (this.GetArticleTagById(id) != null)
            {
                _context.ArticleTags.Remove(this.GetArticleTagById(id));
                _context.SaveChanges();
                return true;

            }
            return false;
        }
        public int AddArticleTag(ArticleTags tag) //zwraca info o przydzielonym id 
        {
            if (tag == null) { return -1; }
            _context.ArticleTags.Add(tag);
            _context.SaveChanges();
            return tag.Id;
        }
    }
}
