using System.ComponentModel.DataAnnotations;
using Azure.Core;

namespace OptionsSetup.API.NamedOptions;

public sealed record SampleKeyOptions
{
    [Required]
    public required string SampleKey { get; set; }

    public required TokenCredential TokenCredential { get; set; }
}