using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.UserOperation.Queries
{
    public class ListUser : IRequest<Response<List<UserDto>>>
    {
    }

    public class ListVersionHandler : IRequestHandler<ListUser, Response<List<UserDto>>>
    {
        readonly IGetUsersRepository _query;
        readonly IMapper _mapper;

        public ListVersionHandler(IMapper mapper, IGetUsersRepository query)
        {
            _mapper = mapper;
            _query = query;  
        }

        public  async Task<Response<List<UserDto>>> Handle(ListUser request, CancellationToken cancellationToken)
        {
            var result =  await _query.GetUsers();
           
            List<UserDto> users = _mapper.Map<List<User>, List<UserDto>>(result);

            return new Response<List<UserDto>>
            {
                Content = users.ToList(),
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
