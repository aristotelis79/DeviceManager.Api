using System.Text.RegularExpressions;
using DeviceManager.Api.Helpers;
using DeviceManager.Api.Model;
using FluentValidation;

namespace DeviceManager.Api.Validation
{
    /// <summary>
    /// Validation rules related to Device controller
    /// </summary>
    public class DeviceViewModelValidationRules : AbstractValidator<DeviceViewModel>, IDeviceViewModelValidationRules
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceViewModelValidationRules"/> class.
        /// <example>
        /// All validation rules can be found here: https://github.com/JeremySkinner/FluentValidation/wiki/a.-Index
        /// </example>
        /// </summary>
        public DeviceViewModelValidationRules()
        {

            
            RuleFor(device => device.DeviceCode)
                //.NotNull()
                //.NotEmpty().WithMessage("Device code is mandatory");
                .Matches(new Regex(Constants.IsGuidRegexExp)).WithMessage("Device code must be Guid")
                .When(device => !string.IsNullOrWhiteSpace(device.DeviceCode));

            RuleFor(device => device.Title)
                .NotNull()
                .NotEmpty().WithMessage("Device code is mandatory");
        }
    }
}
