using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Devices
{
    public class List
    {
        public class Query : IRequest<Result<List<DeviceDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<DeviceDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<DeviceDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var devices = await _context.Devices.ProjectTo<DeviceDto>(_mapper.ConfigurationProvider).ToListAsync();

                if (devices == null) return Result<List<DeviceDto>>.Success(new List<DeviceDto>());

                return Result<List<DeviceDto>>.Success(devices);
            }
        }
    }
}
