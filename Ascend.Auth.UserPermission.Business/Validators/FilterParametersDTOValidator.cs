using Ascend.Auth.UserPermission.Business.Models;
using FluentValidation;

namespace Ascend.Auth.UserPermission.Business.Validators {
    public class FilterParametersDTOValidator : AbstractValidator<FilterParametersDTO> {

        private const string c_InvalidMessage = "Invalid filter parameters";

        public FilterParametersDTOValidator() {

            RuleSet("Always", () =>
            {
                RuleFor(filterParamsDefinition => filterParamsDefinition)
                    .NotNull()
                    .WithMessage(c_InvalidMessage);

                RuleFor(filterParamsDefinition => filterParamsDefinition.Predicates)
                    .NotEmpty()
                    .WithMessage(c_InvalidMessage);
            });
            
        }

    }
}
