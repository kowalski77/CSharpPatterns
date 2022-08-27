using System.ComponentModel.DataAnnotations;
using OptionsSetup.API.Support;

namespace OptionsSetup.API.One;

public class FooOptions : IValidatable
{
    [Required]
    public string Name { get; init; } = default!;

    [Range(0, 1000)]
    public int Number { get; init; }

    public void Validate()
    {
        Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
    }
}
