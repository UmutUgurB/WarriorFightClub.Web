using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorFightClub.Application.Repositories.Blogs;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Domain.Enums;

namespace WarriorFightClub.Application.Features.Blogs.Commands.DeleteBlog
{
    public sealed class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, bool>
    {
        private readonly IBlogRepository _repo;
        private readonly IUnitOfWork _uow;

        public DeleteBlogCommandHandler(IBlogRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(request.Id, tracking: true, ct: ct);
            if (entity is null) return false;

            entity.Status = BlogStatus.Draft; 
            _repo.Update(entity);
            await _uow.SaveChangesAsync(ct);

            return true;
        }
    }
}
