using FluentValidation;
using WarriorFightClub.Application.Features.Categories.Commands.CreateCategory;

namespace WarriorFightClub.Application.Validations.CategoryValidators
{
    public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}
