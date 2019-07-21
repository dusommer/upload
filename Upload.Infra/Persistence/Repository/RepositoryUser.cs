using Upload.Domain.Entities;
using Upload.Domain.Interfaces.Repositories;
using Upload.Infra.Persistence.Repository.Base;

namespace Upload.Infra.Persistence.Repository
{
    public class RepositoryUser : RepositoryBase<User, int>, IRepositoryUser
    {
        protected readonly UploadContext _context;

        public RepositoryUser(UploadContext context) : base(context)
        {
            _context = context;
        }
    }
}
