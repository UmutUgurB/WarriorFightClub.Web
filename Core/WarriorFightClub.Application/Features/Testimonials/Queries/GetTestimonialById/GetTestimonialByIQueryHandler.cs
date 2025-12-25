using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Features.Testimonials.Dtos;
using WarriorFightClub.Application.Repositories.Testimonials;

namespace WarriorFightClub.Application.Features.Testimonials.Queries.GetTestimonialById
{
    public sealed class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, TestimonialDto?>
    {
        private readonly ITestimonialRepository _repo;
        private readonly IMapper _mapper;

        public GetTestimonialByIdQueryHandler(ITestimonialRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TestimonialDto?> Handle(GetTestimonialByIdQuery request, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(request.Id, tracking: false, ct);
            return entity is null ? null : _mapper.Map<TestimonialDto>(entity);
        }
    }
}
