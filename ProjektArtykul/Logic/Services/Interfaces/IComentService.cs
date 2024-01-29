using Logic.Dto.Coment;
using Logic.Enums;

namespace Logic.Services.Interfaces
{
    public interface IComentService
    {
        List<ComentDto> GetList();
        ComentDto GetComent(long id);
        ComentDeleteStatus Delete(long id);
        long Add(ComentAddDto article);
        bool Update(long id, ComentAddDto mark, int AuthorId);
      
    }
}
