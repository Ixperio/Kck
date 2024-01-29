using DB.Entities;
using Logic.Dto.User;
using Logic.Enums;
using Logic.Services.Interfaces;
using Logic.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.Dto.Article;
using DB;
using System.Net.Http;

namespace ProjektArtykuly.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IHttpContextAccessor httpContext;
        public UserController(IUserService userService, IHttpContextAccessor httpContext)
        {
            this.userService = userService;
            this.httpContext = httpContext;
        }
        //lista articles (wszystkie)
        // {url}/User/GetList/
        [HttpGet]
        public ActionResult<List<User>> GetList()
        {
            return Ok(userService.GetList());
        }

        //lista pobranie pojedynczego artykułu
        // {url}/User/GetArticle/{id}

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            var result = userService.GetUser(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        //utworz nowego użytkownika
        // {url}/User/Add/
        [HttpPost]
        public ActionResult Add([FromBody] UserAddDto user)
        {
            var result = userService.Add(user);
            return Ok(result);
        }

        //zaloguj uzytkownika
        [HttpPost]
        public ActionResult Login([FromBody] UserLoginDto user)
        {
            var result = userService.Login(user);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        //aktualizuj uzytkownika
        // {url}/User/Update/
        [HttpPatch("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UserEditDto user)
        {
            var result = userService.Update(id, user);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        //usun uzytkownika
        // {url}/User/Delete/
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
           // string role = httpContext.HttpContext.Session.GetString("LoggedUserRole");
            if(true)
            {
                var result = userService.Delete(id);
                return result switch
                {
                    UserDeleteStatus.Ok => Ok(id),
                    UserDeleteStatus.UserCannotBeDeleted => StatusCode(StatusCodes.Status405MethodNotAllowed)
                };
            }
            return NotFound();
        }
    }
}
