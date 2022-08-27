using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace OptionsSetup.API.Two;

public class BarOptionsValidation : IValidateOptions<BarOptions>
{
    public ValidateOptionsResult Validate(string name, BarOptions options) 
    {
        // You can do more complex validation here with logic and exceptions.
        Validator.ValidateObject(options, new ValidationContext(options), validateAllProperties: true);

        return ValidateOptionsResult.Success;
    }
}
