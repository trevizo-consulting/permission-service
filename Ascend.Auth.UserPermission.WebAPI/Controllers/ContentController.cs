using Ascend.Auth.UserPermission.Business.Models;
using Ascend.Auth.UserPermission.Business.Services.Interfaces;
using Ascend.Auth.UserPermission.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ascend.Auth.UserPermission.WebAPI.Controllers {
    public class ContentController : Controller {

        private IContentSetService _contentSetService;


        public ContentController(IContentSetService service) {
            _contentSetService = service;
        }

        /// <summary>
        /// Return users all content catelog permissions.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpGet("[controller]/content-sets")]
        [ProducesResponseType(typeof(ContentSetDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorDTO), 422)]
        public async Task<IActionResult> Get() {

            try
            {


                IList<ContentSetDTO> contentSetDTOs = await _contentSetService.GetPermissions(); // pretend this is coming from HttpClient

               
                return new JsonResult(contentSetDTOs) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {

                return new JsonResult(ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }


        }
    }
}
