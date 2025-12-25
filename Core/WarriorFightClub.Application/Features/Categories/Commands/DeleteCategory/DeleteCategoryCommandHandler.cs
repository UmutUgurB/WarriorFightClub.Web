using MediatR;
using WarriorFightClub.Application.Repositories.Blogs;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Domain.Constants;

namespace WarriorFightClub.Application.Features.Categories.Commands.DeleteCategory
{
    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _catRepo;
        private readonly IBlogRepository _blogRepo;
        private readonly IUnitOfWork _uow;

        public DeleteCategoryCommandHandler(ICategoryRepository catRepo, IBlogRepository blogRepo, IUnitOfWork uow)
        {
            _catRepo = catRepo;
            _blogRepo = blogRepo;
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken ct)
        {
            if (request.Id == SystemCategoryIds.General)
                throw new InvalidOperationException("Genel kategorisi silinemez.");

            var category = await _catRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);
            if (category is null) return false;

            var general = await _catRepo.GetByIdAsync(SystemCategoryIds.General, tracking: false, ct: ct);
            if (general is null)
                throw new InvalidOperationException("Genel kategorisi bulunamadı. Seed/migration kontrol et.");


            await _blogRepo.ReassignCategoryAsync(request.Id, SystemCategoryIds.General, ct);


            _catRepo.Remove(category);

            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }

}
