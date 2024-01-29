using DB.Entities;
using Logic.Services.Interfaces;
using Logic.Dto.Tag;
using ProjektArtykuly.Models;
using Logic.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ProjektArtykuly.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TagController : ControllerBase
    {

        private ITagService tagService;
        

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }
        //lista articles (wszystkie)
        // {url}/Tag/GetList/
        [HttpGet]
        public ActionResult<List<TagModel>> GetList()
        {
            return Ok(tagService.GetList());
        }

        //lista pobranie pojedynczego artykułu
        // {url}/Tag/GetTag/{id}

        [HttpGet("{id}")]

        public ActionResult GetTag(int id)
        {
            var result = tagService.GetTag(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }



        [HttpGet("{id}")]

        public ActionResult<List<TagModel>> GetAllByArticleId(int id)
            {
                var result = tagService.GetAllByArticleId(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
                //pobierz srednia ocen artykułu

                //utworz nowy artykuł
                // {url}/Tag/Add/
              //  [HttpPost]
        public ActionResult Add([FromBody] TagAddDto tag)
        {
            var result = tagService.Add(tag);
            return Ok(result);
        }

        //edytuj dane article
        // {url}/Tag/Update/
       // [HttpPatch("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] TagAddDto tag, int UserId)
        {
            var result = tagService.Update(id, tag, UserId);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        //usun article
        // {url}/Tag/Delete/
      //  [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var result = tagService.Delete(id);
            return result switch
            {
                TagDeleteStatus.Ok => NoContent(),
                TagDeleteStatus.TagCannotBeDeleted => StatusCode(StatusCodes.Status405MethodNotAllowed)
            };
        }
    }
}
