using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.UseCase.UserOperation.Commands.Create
{
    public class CreateUserCommand : IRequest<Response<CreateUserResponse>>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Birthday { get; set; }
        public string? Gender { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<CreateUserResponse>>
    {
        readonly ICreateUserRepository _repository;
        readonly IUnitOfWork _unitOfWork;
        readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(ICreateUserRepository repository, IUnitOfWork unitOfWork, ILogger<CreateUserCommandHandler> logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Response<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //buscar por email

            DateTime.TryParse(request.Birthday, out DateTime birthday);
            var entity = new User
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthday = birthday,
                Gender = request.Gender
            };
            _repository.CreateUser(entity);
            await _unitOfWork.SaveChanges();
            _logger.LogDebug("the user was add correctly");

            return new Response<CreateUserResponse>
            {
                Content = new CreateUserResponse
                {
                    Message = "Success",
                    Id = entity.Id
                },
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
    }
}
