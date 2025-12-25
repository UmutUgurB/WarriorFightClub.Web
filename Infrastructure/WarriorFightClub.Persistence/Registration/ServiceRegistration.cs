using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarriorFightClub.Application.Repositories;
using WarriorFightClub.Application.Repositories.Abouts;
using WarriorFightClub.Application.Repositories.Banners;
using WarriorFightClub.Application.Repositories.Blogs;
using WarriorFightClub.Application.Repositories.Packages;
using WarriorFightClub.Application.Repositories.Services;
using WarriorFightClub.Application.Repositories.Testimonials;
using WarriorFightClub.Application.Repositories.Trainers;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Persistence.Contexts;
using WarriorFightClub.Persistence.Repository;
using WarriorFightClub.Persistence.Repository.Abouts;
using WarriorFightClub.Persistence.Repository.Banners;
using WarriorFightClub.Persistence.Repository.Blogs;
using WarriorFightClub.Persistence.Repository.Categories;
using WarriorFightClub.Persistence.Repository.Packages;
using WarriorFightClub.Persistence.Repository.Services;
using WarriorFightClub.Persistence.Repository.Testimonials;
using WarriorFightClub.Persistence.Repository.Trainers;
using WarriorFightClub.Persistence.Repository.UnitOfWork;

namespace WarriorFightClub.Persistence.Registration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlCon")));

            service.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); 
            service.AddScoped<IUnitOfWork,UnitOfWork>();    
            service.AddScoped<IAboutRepository,AboutRepository>();
            service.AddScoped<IBannerRepository, BannerRepository>();
            service.AddScoped<IBlogRepository,BlogRepository>();    
            service.AddScoped<IPackageRepository,PackageRepository>();
            service.AddScoped<IServiceRepository, ServiceRepository>();
            service.AddScoped<ITestimonialRepository, TestimonialRepository>();
            service.AddScoped<ITrainerRepository,TrainerRepository>();  
            service.AddScoped<ICategoryRepository,CategoryRepository>();  
            return service;
        }
    }
}
