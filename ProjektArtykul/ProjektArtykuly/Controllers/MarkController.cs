using DB.Entities;
using Logic.Services.Interfaces;
using Logic.Dto.Mark;
using Logic.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ProjektArtykuly.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MarkController : ControllerBase
    {

        private IMarkService markService;

        public MarkController(IMarkService markService)
        {
            this.markService = markService;
        }
        //lista articles (wszystkie)
        // {url}/Mark/GetList/
        [HttpGet]
        public ActionResult<List<Marks>> GetList()
        {
            return Ok(markService.GetList());
        }

        //lista pobranie pojedynczego artykułu
        // {url}/Mark/GetMark/{id}

        [HttpGet("{id}")]
    
        public ActionResult GetMark(long id)
        {
            var result = markService.GetMark(id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        //pobierz srednia ocen artykułu

        [HttpGet("{id}")]
        public ActionResult GetArticleMarkMean(int articleId)
        {
             double res = markService.CountAllMarksMeanByArticleId(articleId);
            if(res != null) {
                return Ok(res);
            }
            return NotFound();
        }
        //utworz nowy artykuł
        // {url}/Mark/Add/
        [HttpPost]
        public ActionResult Add([FromBody] MarkAddDto mark)
        {
            var result = markService.Add(mark);
            return Ok(result);
        }

        //edytuj dane article
        // {url}/Mark/Update/
        [HttpPatch("{id}")]
        public ActionResult Update([FromRoute] long id, [FromBody] MarkAddDto mark, int UserId)
        {
            var result = markService.Update(id, mark, UserId);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        //usun article
        // {url}/Mark/Delete/
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
            var result = markService.Delete(id);
            return result switch
            {
                MarkDeleteStatus.Ok => NoContent(),
                MarkDeleteStatus.MarkCannotBeDeleted => StatusCode(StatusCodes.Status405MethodNotAllowed)
            };
        }
    }
}
