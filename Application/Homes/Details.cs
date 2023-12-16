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
    public class Details
    {
        public class Query : IRequest<Result<HomeDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<HomeDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<HomeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var home = await _context.Homes
                    .ProjectTo<HomeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(s => s.Id == request.Id);

                if (home == null) return null;

                return Result<HomeDto>.Success(home);
            }
        }
    }
}
