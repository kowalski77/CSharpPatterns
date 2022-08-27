using System.ComponentModel.DataAnnotations;

namespace OptionsSetup.API.Two;

public class BarOptions
{
    public bool IsActive { get; init; }

    [Range(0, 100)]
    public int Position { get; init; }
}
