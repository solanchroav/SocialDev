using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.UseCase.UserOperation.Commands.Update
{
    public class UpdateUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string? Password { get; set; } = null!;
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? Birthday { get; set; }
        public string? Gender { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<string>>
    {
        readonly IGetUserByIdRepository _query;
        readonly IUpdateUserRepository _repository;
        readonly IUnitOfWork _unitOfWork;
        readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUpdateUserRepository repository, IUnitOfWork unitOfWork, ILogger<UpdateUserCommandHandler> logger, IGetUserByIdRepository query)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _query = query;
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            int.TryParse(request.Id, out int id);
            var user = await _query.GetUserById(id);
            var response = new Response<string>();
            
            if (user is null)
            {
                response.AddNotification("#404", nameof(request.Id), string.Format(ErrorMessage.NOT_FOUND_RECORD_ID, "User", request.Id));
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }

            user.FirstName = string.IsNullOrEmpty(request.FirstName) ? user.FirstName : request.FirstName;
            user.LastName = string.IsNullOrEmpty(request.LastName) ? user.LastName : request.LastName;
            DateTime.TryParse(request.Birthday, out DateTime birthday);
            user.Birthday = request.Birthday == null ? user.Birthday : birthday;
            user.Gender = string.IsNullOrEmpty(request.Gender) ? user.Gender : request.Gender;

            _repository.UpdateUser(user);
            await _unitOfWork.SaveChanges();
            _logger.LogDebug("the user was update correctly");

            return response;
        }
    }
}
