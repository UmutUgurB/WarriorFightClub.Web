using MediatR;
using WarriorFightClub.Application.Repositories.Services;
using WarriorFightClub.Application.Repositories.UnitOfWork;

namespace WarriorFightClub.Application.Features.Services.Commands.UpdateService
{
    public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, bool>
    {
        private readonly IServiceRepository _repo;
        private readonly IUnitOfWork _uow;

        public UpdateServiceCommandHandler(IServiceRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken ct)
        {
            var service = await _repo.GetByIdAsync(request.Id, tracking: true, ct);
            if (service is null) return false;

            service.Title = request.Title;
            service.Description = request.Description;
            service.ImageUrl = request.ImageUrl;
            service.IsActive = request.IsActive;

            _repo.Update(service);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}
