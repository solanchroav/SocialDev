using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCase.AuthOperation.Queries
{
    public class GetUserAuth : IRequest<Response<UserLoginDto>>
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }

    public class GetUserAuthHandler : IRequestHandler<GetUserAuth, Response<UserLoginDto>>
    {
        readonly IUserAuthenticationRepository _query;
        readonly IUnitOfWork _unitOfWork;


        public GetUserAuthHandler(IUserAuthenticationRepository query, IUnitOfWork unitOfWork)
        {
            _query = query;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<UserLoginDto>> Handle(GetUserAuth request, CancellationToken cancellationToken)
        {
            var response = new Response<UserLoginDto>();

            var entity = new UserLogin
            {
                Email = request.Email,
                Password = request.Password
            };

            bool validUser = await _query.ValidateUserAsync(entity);
            await _unitOfWork.SaveChanges();

            UserLoginDto userLoginDto = new UserLoginDto();
            
            if (validUser)
            {
                userLoginDto.Token = await _query.CreateTokenAsync();
                response.Content = userLoginDto;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            } else
            {
                response.AddNotification("#404", nameof(request.Email), string.Format(ErrorMessage.NOT_FOUND_RECORD_ID, "Email", request.Email));
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
            }


            return response;
        }
    }
}
