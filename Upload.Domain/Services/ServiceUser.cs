using Upload.Domain.Arguments.User;
using Upload.Domain.Entities;
using Upload.Domain.Interfaces.Repositories;
using Upload.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upload.Domain.Services
{
    public class ServiceUser : Notifiable, IServiceUser
    {

        private readonly IRepositoryUser _repositoryUser;

        public ServiceUser()
        {

        }

        public ServiceUser(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public InsertUserResponse InsertUser(InsertUserRequest request)
        {
            User user = null;

            if (request == null)
            {
                AddNotification("InsertFileRequest", "Request is required.");
            }

            user = new User(request?.Email, request?.Password);

            AddNotifications(user);

            if (IsInvalid())
            {
                return null;
            }

            user = _repositoryUser.Insert(user);

            return (InsertUserResponse)user;
        }
    }
}
