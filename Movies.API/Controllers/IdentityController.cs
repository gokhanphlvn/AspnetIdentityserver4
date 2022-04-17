namespace Movies.API.Controllers
{
    #region USINGS
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    #endregion

    [Authorize, ApiController, Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
