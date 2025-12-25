using FluentValidation;

namespace WarriorFightClub.Application.Features.Blogs.Commands.CreateBlog;

public sealed class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).NotEmpty().MinimumLength(20);
        RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(600);
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.Status).IsInEnum();
    }
}
