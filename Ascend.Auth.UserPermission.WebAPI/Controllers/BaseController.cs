using Microsoft.AspNetCore.Mvc;
using Ascend.Auth.UserPermission.Business.Validators;
using FluentValidation;
using Ascend.Auth.UserPermission.Business.Models;

namespace Ascend.Auth.UserPermission.WebAPI.Controllers {

    public class BaseController : Controller {

        public BaseController  ValidateParameters(FilterParametersDTO parameters) {

            FilterParametersDTOValidator validator = new FilterParametersDTOValidator();

            validator.ValidateAndThrow(parameters);

            return this;
        }
    }
}
