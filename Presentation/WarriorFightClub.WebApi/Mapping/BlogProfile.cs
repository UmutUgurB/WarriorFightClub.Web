using AutoMapper;
using WarriorFightClub.Application.Features.Blogs.Commands.CreateBlog;
using WarriorFightClub.Application.Features.Blogs.Commands.UpdateBlog;
using WarriorFightClub.WebApi.Contracts.Blogs;

namespace WarriorFightClub.WebApi.Mapping
{
    public sealed class BlogRequestProfile : Profile
    {
        public BlogRequestProfile()
        {
            CreateMap<CreateBlogRequest, CreateBlogCommand>();
            CreateMap<UpdateBlogRequest, UpdateBlogCommand>();
        }
    }
}
