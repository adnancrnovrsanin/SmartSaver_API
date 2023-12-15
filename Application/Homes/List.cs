using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Homes
{
    public class List
    {
        public class Query : IRequest<Result<List<Home>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<Home>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<Home>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var schedules = await _context.Homes.ToListAsync();

                if (schedules == null) return Result<List<Home>>.Success(new List<Home>());

                return Result<List<Home>>.Success(schedules);
            }
        }
    }
}