using AutoMapper;
using WarriorFightClub.Application.Features.Trainers.Commands.CreateTrainer;
using WarriorFightClub.Application.Features.Trainers.Commands.UpdateTrainer;
using WarriorFightClub.WebApi.Contracts.Trainers;

namespace WarriorFightClub.WebApi.Mapping
{
    public class TrainerMapping : Profile
    {
        public TrainerMapping()
        {
            CreateMap<CreateTrainerRequest, CreateTrainerCommand>();

            CreateMap<UpdateTrainerRequest, UpdateTrainerCommand>()
                .ForCtorParam("Id", opt => opt.MapFrom(_ => Guid.Empty));
        }
    }
}
