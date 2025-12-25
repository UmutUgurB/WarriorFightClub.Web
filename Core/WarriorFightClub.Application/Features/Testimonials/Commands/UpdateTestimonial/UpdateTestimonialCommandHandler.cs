using MediatR;
using WarriorFightClub.Application.Repositories.Testimonials;
using WarriorFightClub.Application.Repositories.UnitOfWork;

namespace WarriorFightClub.Application.Features.Testimonials.Commands.UpdateTestimonial
{
    public sealed class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand, bool>
    {
        private readonly ITestimonialRepository _repo;
        private readonly IUnitOfWork _uow;

        public UpdateTestimonialCommandHandler(ITestimonialRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<bool> Handle(UpdateTestimonialCommand request, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(request.Id, tracking: true, ct);
            if (entity is null) return false;

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.IsShown = request.IsShown;

            _repo.Update(entity);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}
