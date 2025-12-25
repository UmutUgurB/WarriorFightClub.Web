using FluentValidation;
using WarriorFightClub.Application.Features.Categories.Commands.UpdateCategory;

namespace WarriorFightClub.Application.Validations.CategoryValidators
{
    public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}
