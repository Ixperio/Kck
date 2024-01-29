using DB.Entities;
using Logic.Services.Interfaces;
using Logic.Dto.Coment;
using Logic.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ProjektArtykuly.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ComentController : ControllerBase
    {

        private IComentService comentService;

        public ComentController(IComentService comentService)
        {
            this.comentService = comentService;
        }
        //lista articles (wszystkie)
        // {url}/Coment/GetList/
        [HttpGet]
        public ActionResult<List<Coments>> GetList()
        {
            return Ok(comentService.GetList());
        }

        //lista pobranie pojedynczego artykułu
        // {url}/Coment/GetComent/{id}

        [HttpGet("{id}")]
    
        public ActionResult GetComent(long id)
        {
            var result = comentService.GetComent(id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        //utworz nowy artykuł
        // {url}/Coment/Add/
        [HttpPost]
        public ActionResult Add([FromBody] ComentAddDto coment)
        {
            var result = comentService.Add(coment);
            return Ok(result);
        }

        //edytuj dane article
        // {url}/Coment/Update/
        [HttpPatch("{id}")]
        public ActionResult Update([FromRoute] long id, [FromBody] ComentAddDto coment, int AuthorId)
        {
            var result = comentService.Update(id, coment, AuthorId);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        //usun article
        // {url}/Coment/Delete/
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
            var result = comentService.Delete(id);
            return result switch
            {
                ComentDeleteStatus.Ok => NoContent(),
                ComentDeleteStatus.ComentCannotBeDeleted => StatusCode(StatusCodes.Status405MethodNotAllowed)
            };
        }
    }
}
