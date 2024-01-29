using DB;
using DB.Entities;
using Logic.Repos.Intrefaces;
using Logic.Dto.User;
using Logic.Dto.Coment;
using System.Security.Cryptography.X509Certificates;

namespace Logic.Repos
{
    public class DbArticleParagraphRepository : IArticleParagraphRepository
    {
        //Kolekcja wprowadzająca do api TESTOWY KOMENTARZ

        private readonly MyDbContext _context;

        public DbArticleParagraphRepository(MyDbContext context)
        {
            this._context = context;
        }

        public List<ArticleParagraph> GetAllBySectionId(long id)
        {
            return _context.ArticleParagraphs.Where(x => x.IsDeleted == false && x.IdSekcji == id).ToList();
        }

        //pobieranie pojedyńczego komentarza po id
        public ArticleParagraph GetOne(long id)
        {
            return _context.ArticleParagraphs.Where(x => x.Id == id && x.IsDeleted == false).SingleOrDefault();
        }
      
        //update artykułu
        public bool Update(ArticleParagraph paragraph)
        {
            if(this.GetOne(paragraph.Id) != null)
            {
                _context.ArticleParagraphs.Update(paragraph);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }
        //dodanie artykułu
        public bool Add(ArticleParagraph paragraph)
        {
            _context.ArticleParagraphs.Add(paragraph);
            _context.SaveChanges();
            return true;
        }
        //usuwanie artykułu
        public bool Delete(long id)
        {
            var itemToDelete = this.GetOne(id);
            if(itemToDelete != null)
            {
                itemToDelete.IsDeleted = true;
                _context.ArticleParagraphs.Update(itemToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
