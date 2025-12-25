using FluentValidation;
using WarriorFightClub.Application.Features.Categories.Commands.DeleteCategory;
using WarriorFightClub.Domain.Constants;

namespace WarriorFightClub.Application.Validations.CategoryValidators
{
    public sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id)
                .Must(id => id != SystemCategoryIds.General)
                .WithMessage("Genel kategorisi silinemez.");
        }
    }
}
