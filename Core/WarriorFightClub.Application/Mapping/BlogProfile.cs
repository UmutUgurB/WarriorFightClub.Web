using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorFightClub.Application.Features.Blogs.Commands.CreateBlog;
using WarriorFightClub.Application.Features.Blogs.Commands.UpdateBlog;
using WarriorFightClub.Application.Features.Blogs.Dtos;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Mapping
{
    public sealed class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, BlogListItemDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Title))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

            CreateMap<Blog, BlogDetailDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Title))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

            CreateMap<CreateBlogCommand, Blog>();
            CreateMap<UpdateBlogCommand, Blog>()
                .ForMember(d => d.Id, o => o.Ignore()); 
        }
    }
}
