using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IGetUserByIdRepository
    {
        Task<UserAuth> GetUserById(int userId);
    }
}
