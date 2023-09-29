using Microsoft.AspNetCore.Mvc;
using Ascend.Auth.UserPermission.Business.Services.Interfaces;
using Ascend.Auth.UserPermission.Business.Models;
using Ascend.Auth.UserPermission.WebAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;


namespace Ascend.Auth.UserPermission.WebAPI.Controllers {
    public class PermissionController : BaseController {

        private IPermissionService _permissionService;
        private ILogger<PermissionController> _logger;
        

        public PermissionController(IPermissionService permissionService, ILogger<PermissionController> logger)
        {
            _permissionService = permissionService;
            _logger = logger; 
        }

        /// <summary>
        /// Return user authority permissions by specifying the permission key. The permission key specifies the structure of the values.
        /// </summary>
        /// <param name="key">The string value of the permission key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpGet("[controller]/{key}")]
        [ProducesResponseType(typeof(PermissionDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorDTO), 422)]
        public async Task<IActionResult> GetByKey([FromRoute, BindRequired]string key)
        {
            try
            {
                if(string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("error with key", "key");
                }

                IList<PermissionDTO> permissionDTOs = await _permissionService.GetByKey(key); // pretend this is coming from HttpClient

                return new JsonResult(permissionDTOs) { StatusCode = StatusCodes.Status200OK };
            }
            catch (ArgumentException ex)
            {

                return new JsonResult(ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = StatusCodes.Status500InternalServerError };
            }

        }


        [HttpGet("[controller]s")]
        [ProducesResponseType(typeof(PermissionDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorDTO), 422)]
        public async Task<IActionResult> GetAll() {

            try
            {
                IList<PermissionDTO> permissionDTOs = await _permissionService.GetAll(); // pretend this is coming from HttpClient

                return new JsonResult(permissionDTOs) { StatusCode = StatusCodes.Status200OK };
            }
            catch (ArgumentException ex)
            {

                return new JsonResult(ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = StatusCodes.Status500InternalServerError };
            }

        }

        [HttpPost("[controller]/search")]
        [ProducesResponseType(typeof(PermissionDTO), 200)]
        [ProducesResponseType(typeof(ErrorDTO), 422)]
        public async Task<IActionResult> Search([FromBody]FilterParametersDTO searchParams) {
            try
            {

                ValidateParameters(searchParams);
                
                IList<PermissionDTO> permissionDTOs = await _permissionService.Search(searchParams);

                return new JsonResult(permissionDTOs) { StatusCode = StatusCodes.Status200OK };
            }
            catch (ArgumentException ex)
            {
                return new JsonResult(ex.Message) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
            catch (ValidationException ex)
            {
                return new JsonResult(ex.Message) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }


    }
}
