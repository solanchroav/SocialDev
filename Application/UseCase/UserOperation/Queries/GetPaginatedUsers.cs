using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.UserOperation.Queries
{
    public class GetPaginatedUsers : IRequest<Response<List<UserDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetPaginatedUsersHandler : IRequestHandler<GetPaginatedUsers, Response<List<UserDto>>>
    {
        readonly IGetUsersRepository _query;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;


        public GetPaginatedUsersHandler(IGetUsersRepository query, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _query = query;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<UserDto>>> Handle(GetPaginatedUsers request, CancellationToken cancellationToken)
        {
           
            var result = await _query.GetPaginatedUsers(request.PageNumber, request.PageSize);
            await _unitOfWork.SaveChanges();

            var metadata = new
            {
                result.TotalCount,
                result.PageIndex,
                result.HasNextPage,
                result.HasPreviousPage,
                result.TotalPages
            };

            List<UserDto> user = _mapper.Map<List<UserAuth>, List<UserDto>>(result.Items);

            return new Response<List<UserDto>>
            {
                Content = user.ToList(),
                StatusCode = System.Net.HttpStatusCode.OK,
                Headers = new Dictionary<string, string>()
                {
                    ["X-Pagination"] = JsonConvert.SerializeObject(metadata)
                }
            };
        }
    }
}
