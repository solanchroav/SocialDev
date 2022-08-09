using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCase.AuthOperation.Create
{
    public class CreateUserAuthCommand : IRequest<Response<CreateUserAuthResponse>>
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = null!;
        public string? Birthday { get; set; }
        public string? Gender { get; set; }
    }

    public class CreateUserAuthCommandHandler : IRequestHandler<CreateUserAuthCommand, Response<CreateUserAuthResponse>>
    {
        readonly IUserAuthenticationRepository _repository;
        readonly IUnitOfWork _unitOfWork;
        readonly ILogger<CreateUserAuthCommandHandler> _logger;

        public CreateUserAuthCommandHandler(IUserAuthenticationRepository repository, IUnitOfWork unitOfWork, ILogger<CreateUserAuthCommandHandler> logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Response<CreateUserAuthResponse>> Handle(CreateUserAuthCommand request, CancellationToken cancellationToken)
        {
            //buscar por email

            DateTime.TryParse(request.Birthday, out DateTime birthday);
            var entity = new UserAuth
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthday = birthday,
                Gender = request.Gender
            };
            await _repository.RegisterUserAsync(entity, request.Password);
            await _unitOfWork.SaveChanges();
            _logger.LogDebug("the user was add correctly");

            return new Response<CreateUserAuthResponse>
            {
                Content = new CreateUserAuthResponse
                {
                    Message = "Success",
                    Email = entity.Email
                },
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
    }
}
