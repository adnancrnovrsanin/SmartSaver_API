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

namespace Application.Homes
{
    public class ListUserHomes
    {
        public class Query : IRequest<Result<List<HomeDto>>>
        {
            public string AppUserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<HomeDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<HomeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var homes = await _context.Homes
                    .Where(h => h.AppUserId == request.AppUserId)
                    .Include(h => h.Devices)
                    .ProjectTo<HomeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                if (homes == null) return Result<List<HomeDto>>.Success(new List<HomeDto>());

                return Result<List<HomeDto>>.Success(homes);
            }
        }
    }
}
