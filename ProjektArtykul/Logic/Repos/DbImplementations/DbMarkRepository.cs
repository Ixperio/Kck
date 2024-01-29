using DB;
using DB.Entities;
using Logic.Repos.Intrefaces;
using Logic.Dto.User;
using Logic.Dto.Coment;
using Logic.Dto.Mark;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;

namespace Logic.Repos
{
    public class DbMarkRepository : IMarksRepository
    {
        //Kolekcja wprowadzająca do api TESTOWY KOMENTARZ
        private readonly MyDbContext _context;

        public DbMarkRepository(MyDbContext context)
        {
            _context = context;
        }

        public long Add(Marks mark)
        {
            mark.Id = _context.Marks.Max(x => (long ?)x.Id).GetValueOrDefault(0) + 1;
            _context.Marks.Add(mark);
            _context.SaveChanges();
            return mark.Id;
        }
        public bool Delete(long id)
        {
            var mark = _context.Marks.SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (mark is null) { return false; }
            mark.IsDeleted = true;
            _context.Marks.Update(mark);
            _context.SaveChanges();
            return true;
        }
        public Marks GetOne(long id)
        {
            var mark = _context.Marks.SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (mark is null) { return null; }
            return mark;
        }
        public List<Marks> GetAll()
        {
            return _context.Marks.Where(x => x.IsDeleted == false).ToList();
        }

        public List<Marks> GetAllByIds(List<long> ids)
        {
            return _context.Marks.Where(x => x.IsDeleted == false && ids.Contains(x.Id)).ToList();
        }
        public List<Marks> GetAllByArticleId(int id)
        {
            var marks = _context.Marks.Where(x => x.ArticleId == id).ToList();
            var ints = new List<long>();

            foreach (var v in marks)
            {
                ints.Add(v.Id);
            }

            return this.GetAllByIds(ints);
        }
        public List<Marks> GetAllByUserId(int id)
        {
            return _context.Marks.Where(x => x.IsDeleted == false && id == x.UserId).ToList();
        }

        public short GetMarkByUserIdAndArticleId(int userId, int articleId)
        {
            var ret = _context.Marks.Where(x => x.IsDeleted == false && userId == x.UserId);
            if(ret.Count() != 0)
            {
                short wynik = ret.Where(x => x.ArticleId == articleId).SingleOrDefault().Mark;
                if (wynik != null)
                {
                    return wynik;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
           
        }

        public double CountAllMarksMeanByArticleId(int articleId)
        {
            var ret = _context.Marks.Where(x => !x.IsDeleted && x.ArticleId == articleId);
            if (!ret.Any())
            {
                return 0;
            }

            double avg = ret.Average(x => x.Mark);
            double roundVal = Math.Round(avg, 1);
            return roundVal;
        }

        public bool Update(Marks mark)
        {
            if (this.GetOne(mark.Id) != null)
            {
                _context.Marks.Update(mark);
                _context.SaveChanges();
                return true;
            }
            return false; 
        }

    }
}
