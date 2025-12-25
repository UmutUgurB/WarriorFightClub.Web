using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Domain.Constants;

namespace WarriorFightClub.Application.Features.Categories.Commands.UpdateCategory
{
    public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _repo;
        private readonly IUnitOfWork _uow;

        public UpdateCategoryCommandHandler(ICategoryRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken ct)
        {
            if (request.Id == SystemCategoryIds.General)
                throw new InvalidOperationException("Genel kategorisi güncellenemez.");

            if (await _repo.ExistsByTitleAsync(request.Title, request.Id, ct))
                throw new InvalidOperationException("Bu isimde bir kategori zaten mevcut.");

            var entity = await _repo.GetByIdAsync(request.Id, tracking: true, ct: ct);
            if (entity is null) return false;

            entity.Title = request.Title.Trim();
            entity.Description = request.Description?.Trim() ?? "";

            _repo.Update(entity);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }


}
