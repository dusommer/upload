﻿using Upload.Domain.Entities;
using Upload.Domain.Interfaces.Repositories.Base;

namespace Upload.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser : IRepositoryBase<User, int>
    {
    }
}
