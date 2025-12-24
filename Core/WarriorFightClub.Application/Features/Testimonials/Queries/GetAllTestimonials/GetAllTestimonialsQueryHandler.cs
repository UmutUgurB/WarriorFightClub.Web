using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Testimonials.Dtos;
using WarriorFightClub.Application.Repositories.Testimonials;

namespace WarriorFightClub.Application.Features.Testimonials.Queries.GetAllTestimonials
{
    public sealed class GetTestimonialsPagedQueryHandler
    : IRequestHandler<GetTestimonialsPagedQuery, PagedResult<TestimonialDto>>
    {
        private readonly ITestimonialRepository _repo;
        private readonly IMapper _mapper;

        public GetTestimonialsPagedQueryHandler(ITestimonialRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PagedResult<TestimonialDto>> Handle(GetTestimonialsPagedQuery request, CancellationToken ct)
        {
            var paged = await _repo.GetPagedAsync(request.Page, request.PageSize, request.IsShown, ct);

            return new PagedResult<TestimonialDto>
            {
                Page = paged.Page,
                PageSize = paged.PageSize,
                TotalCount = paged.TotalCount,
                TotalPages = paged.TotalPages,
                Items = _mapper.Map<List<TestimonialDto>>(paged.Items)
            };
        }
    }
}
