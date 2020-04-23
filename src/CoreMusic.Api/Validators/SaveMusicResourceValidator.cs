using CoreMusic.Api.Resources;
using FluentValidation;

namespace CoreMusic.Api.Validators
{
  public class SaveMusicResourceValidator : AbstractValidator<SaveMusicResource>
  {
    public SaveMusicResourceValidator()
    {
      RuleFor(m => m.Name)
                   .NotEmpty()
                   .MaximumLength(50);

      RuleFor(m => m.ArtistId)
          .NotEmpty()
          .WithMessage("'Artist Id' must not be 0.");
    }
  }
}