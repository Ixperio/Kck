using DB.Entities;
using Logic.Services.Interfaces;
using Logic.Dto.Article;
using ProjektArtykuly.Models;
using Logic.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ProjektArtykuly.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ArticleController : ControllerBase
    {

        private IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        //lista articles (wszystkie)
        // {url}/Article/GetList/
        [HttpGet]
        public ActionResult<List<ArticleModelBig>> GetList()
        {
            var art = articleService.GetList();
            if(art == null)
            {
                return NotFound();
            }
            return Ok(art);
        }

        //lista pobranie pojedynczego artykułu
        // {url}/Article/GetArticle/{id}

        [HttpGet("{id}")]

        public ActionResult<ArticleModelBig> GetArticle(int id)
        {
            var result = articleService.GetArticle(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<List<ArticleModelMini>> GetBest()
        {
            var result = articleService.GetBest();
            if(result != null) { return Ok(result); }
            return NotFound();
        }
        [HttpGet("{id}")]
        public ActionResult<List<ArticleModelMini>> GetNewest()
        {
            var result = articleService.GetNewest();
            if (result != null) { return Ok(result); }
            return NotFound();
        }
        //utworz nowy artykuł
        // {url}/Article/Add/
        [HttpPost]
        public ActionResult Add([FromBody] ArticleAddEditDto article)
        {
            var result = articleService.Add(article);
            return Ok(result);
        }

        //edytuj dane article
        // {url}/Article/Update/
        [HttpPatch("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] ArticleAddEditDto article)
        {
            var result = articleService.Update(id, article);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        //usun article
        // {url}/Article/Delete/
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var result = articleService.Delete(id);
            return result switch
            {
                ArticleDeleteStatus.Ok => NoContent(),
                ArticleDeleteStatus.ArticleCannotBeDeleted => StatusCode(StatusCodes.Status405MethodNotAllowed)
            };
        }
    }
}
