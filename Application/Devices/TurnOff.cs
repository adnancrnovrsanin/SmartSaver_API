using Application.Core;
using AutoMapper;
using Domain;
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
    public class TurnOff
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid DeviceId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var device = await _context.Devices.FirstOrDefaultAsync(x => x.Id == request.DeviceId);

                if (device == null) return Result<Unit>.Failure("Home not found");

                var runPeriod = await _context.RunPeriods.SingleOrDefaultAsync(x => x.DeviceId == request.DeviceId && x.EndTime == null);

                if (runPeriod == null) return Result<Unit>.Failure("Device hasn't been running");

                runPeriod.EndTime = DateTime.UtcNow;
                device.IsOn = false;

                _context.RunPeriods.Update(runPeriod);
                _context.Devices.Update(device);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to turn on device");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
