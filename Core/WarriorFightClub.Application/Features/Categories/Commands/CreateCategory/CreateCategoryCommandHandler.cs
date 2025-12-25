using MediatR;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Features.Categories.Commands.CreateCategory
{
    public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repo;
        private readonly IUnitOfWork _uow;

        public CreateCategoryCommandHandler(ICategoryRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken ct)
        {

            if (await _repo.ExistsByTitleAsync(request.Title, null, ct))
                throw new InvalidOperationException("Bu isimde bir kategori zaten mevcut.");

            var entity = new Category
            {
                Title = request.Title.Trim(),
                Description = request.Description?.Trim() ?? ""
            };

            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);

            return entity.Id;
        }
    }

}
