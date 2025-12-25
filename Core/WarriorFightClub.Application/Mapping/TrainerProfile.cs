using AutoMapper;
using WarriorFightClub.Application.Features.Trainers.Commands.CreateTrainer;
using WarriorFightClub.Application.Features.Trainers.Commands.UpdateTrainer;
using WarriorFightClub.Application.Features.Trainers.Dtos;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Mapping
{
    public sealed class TrainerProfile : Profile
    {
        public TrainerProfile()
        {
            CreateMap<Trainer, TrainerDto>();

            CreateMap<CreateTrainerCommand, Trainer>();

            CreateMap<UpdateTrainerCommand, Trainer>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatedDate, opt => opt.Ignore());
        }
    }
}
