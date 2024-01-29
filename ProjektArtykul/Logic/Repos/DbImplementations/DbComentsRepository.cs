using DB;
using DB.Entities;
using Logic.Repos.Intrefaces;
using Logic.Dto.User;
using Logic.Dto.Coment;
using System.Security.Cryptography.X509Certificates;

namespace Logic.Repos
{
    public class DbComentsRepository : IComentsRepository
    {
        //Kolekcja wprowadzająca do api TESTOWY KOMENTARZ

        private readonly MyDbContext _context;

        public DbComentsRepository(MyDbContext context)
        {
            this._context = context;
        }


        //pobieranie pojedyńczego komentarza po id
        public Coments GetOne(long id)
        {
            return _context.Coments.Where(x => x.Id == id && x.IsDeleted == false).SingleOrDefault();
        }
        //pobieranie wszystkich komentarzy
        public List<Coments> GetAll()
        {
            return _context.Coments.Where(x => x.IsDeleted == false).ToList();
        }
        //pobieranie komentarzy po liście ich id
        public List<Coments> GetAllByIds(List<long> ids)
        {
            return _context.Coments.Where(x => x.IsDeleted == false && ids.Contains(x.Id)).ToList();
        }
        //pobieranie komentarzy po id artykułu
        public List<Coments> GetAllByArticleId(int articleId)
        {
           
            return _context.Coments.Where(x => x.IsDeleted == false && articleId == x.ArticleId).ToList();
        }

        //pobieranie komentarzy po id ich autora
        public List<Coments> GetAllByAuthorId(int authorId)
        {
            return _context.Coments.Where(x => x.IsDeleted == false && authorId == x.AuthorId).ToList();
        }
        //update artykułu
        public bool Update(Coments coment)
        {
            var comentEdit = _context.Coments.Where(x => x.Id == coment.Id).SingleOrDefault();
            if (comentEdit != null) { return false; }
            comentEdit.Description = coment.Description;
            comentEdit.Created = DateTime.Now;
            _context.Coments.Update(comentEdit);
            _context.SaveChanges();
            return true;
        }
        //dodanie artykułu
        public long Add(Coments coment)
        {
            _context.Coments.Add(coment);
            _context.SaveChanges();
            return coment.Id;
        }
        //usuwanie artykułu
        public bool Delete(long id)
        {
            var itemToDelete = GetOne(id);
            if(itemToDelete != null)
            {
                itemToDelete.IsDeleted = true;
                _context.Coments.Update(itemToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
