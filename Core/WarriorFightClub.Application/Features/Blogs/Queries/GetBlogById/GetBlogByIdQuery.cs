using MediatR;
using WarriorFightClub.Application.Features.Blogs.Dtos;

namespace WarriorFightClub.Application.Features.Blogs.Queries.GetBlogById;

public sealed record GetBlogByIdQuery(Guid Id) : IRequest<BlogDetailDto?>;
