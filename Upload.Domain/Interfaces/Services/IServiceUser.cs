using Upload.Domain.Arguments.User;
using Upload.Domain.Interfaces.Services.Base;

namespace Upload.Domain.Interfaces.Services
{
    public interface IServiceUser : IServiceBase
    {
        InsertUserResponse InsertUser(InsertUserRequest request);
    }
}
