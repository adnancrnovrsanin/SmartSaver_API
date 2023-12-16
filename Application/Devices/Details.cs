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
    public class Details
    {
        public class Query : IRequest<Result<DeviceDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<DeviceDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<DeviceDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var home = await _context.Homes
                    .ProjectTo<DeviceDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(s => s.Id == request.Id);

                if (home == null) return null;

                return Result<DeviceDto>.Success(home);
            }
        }
    }
}
