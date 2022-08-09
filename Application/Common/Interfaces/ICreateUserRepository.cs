using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ICreateUserRepository
    {
        void CreateUser(User user);
    }
}
