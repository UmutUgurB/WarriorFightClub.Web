using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorFightClub.Application.Features.Testimonials.Dtos;
using WarriorFightClub.Application.Repositories.Testimonials;

namespace WarriorFightClub.Application.Features.Testimonials.Queries.GetAllTestimonials
{
    public sealed class GetShownTestimonialsQueryHandler
    : IRequestHandler<GetShownTestimonialsQuery, List<TestimonialDto>>
    {
        private readonly ITestimonialRepository _repo;
        private readonly IMapper _mapper;

        public GetShownTestimonialsQueryHandler(ITestimonialRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<TestimonialDto>> Handle(GetShownTestimonialsQuery request, CancellationToken ct)
        {
            var list = await _repo.GetShownListAsync(ct);
            return _mapper.Map<List<TestimonialDto>>(list);
        }
    }
}
