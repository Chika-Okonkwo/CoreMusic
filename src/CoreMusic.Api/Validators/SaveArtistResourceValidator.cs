using CoreMusic.Api.Resources;
using FluentValidation;

namespace CoreMusic.Api.Validators
{
  public class SaveArtistResourceValidator : AbstractValidator<SaveArtistResource>
  {
    public SaveArtistResourceValidator()
    {
      RuleFor(a => a.Name)
          .NotEmpty()
          .MaximumLength(50);
    }
  }
}