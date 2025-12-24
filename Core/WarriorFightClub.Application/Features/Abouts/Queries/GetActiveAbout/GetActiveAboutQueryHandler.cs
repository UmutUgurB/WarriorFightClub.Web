using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Features.Abouts.Dtos;
using WarriorFightClub.Application.Repositories.Abouts;

namespace WarriorFightClub.Application.Features.Abouts.Queries.GetActiveAbout
{
    public sealed class GetActiveAboutQueryHandler : IRequestHandler<GetActiveAboutQuery, AboutDto?>
    {
        private readonly IMapper _mapper;
        private readonly IAboutRepository _aboutRepository;

        public GetActiveAboutQueryHandler(IMapper mapper, IAboutRepository aboutRepository)
        {
            _mapper = mapper;
            _aboutRepository = aboutRepository;
        }

        public async Task<AboutDto?> Handle(GetActiveAboutQuery request, CancellationToken cancellationToken)
        {
           var about = await _aboutRepository.GetActiveAsync(cancellationToken);
            return about is null ? null : _mapper.Map<AboutDto>(about); 
        }
    }
}
