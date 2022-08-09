using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IUpdateUserRepository
    {
        void UpdateUser(UserAuth user);
    }
}
