using AutoMapper;
using WarriorFightClub.Application.Features.Categories.Commands.CreateCategory;
using WarriorFightClub.Application.Features.Categories.Commands.UpdateCategory;
using WarriorFightClub.WebApi.Contracts.Categories;

namespace WarriorFightClub.WebApi.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {

            CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
            CreateMap<UpdateCategoryRequest, UpdateCategoryCommand>();
        }
    }
}
