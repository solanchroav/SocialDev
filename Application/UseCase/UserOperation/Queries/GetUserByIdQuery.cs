using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCase.UserOperation.Queries
{
    public class GetUserByIdQuery : IRequest<Response<UserDto>>
    {
        public string Id { get; set; }
    }

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Response<UserDto>>
    {
        readonly IGetUserByIdRepository _query;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;


        public GetUserByIdHandler(IGetUserByIdRepository query, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _query = query;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            int.TryParse(request.Id, out int id);
            var result = await _query.GetUserById(id);
            await _unitOfWork.SaveChanges();

            UserDto user = _mapper.Map<UserAuth, UserDto>(result);

            return new Response<UserDto>
            {
                Content = user,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
