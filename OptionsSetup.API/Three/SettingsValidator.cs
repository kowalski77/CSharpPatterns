using FluentValidation;

namespace OptionsSetup.API.Three;

public class SettingsValidator : AbstractValidator<Settings>
{
    public SettingsValidator()
    {
        this.RuleFor(x => x.DisplayName).NotEmpty();
        this.RuleFor(x => x.WebhookUrl)
            .NotEmpty()
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrEmpty(x.WebhookUrl));
    }
}
