using FluentValidation;

namespace WarriorFightClub.Application.Features.Blogs.Commands.UpdateBlog;

public sealed class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).NotEmpty().MinimumLength(20);
        RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(600);
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.Status).IsInEnum();
    }
}
