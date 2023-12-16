using Application.Core;
using AutoMapper;
using Domain.ModelDTOs;
using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Devices
{
    public class TurnOn
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

                var runPeriod = new RunPeriod
                {
                    StartTime = DateTime.UtcNow,
                    EndTime = null,
                    PowerSpent = 0,
                    DeviceId = device.Id,
                };
                if (device.RunPeriods == null) device.RunPeriods = new List<RunPeriod>();
                device.RunPeriods.Add(runPeriod);
                device.IsOn = true;

                _context.RunPeriods.Add(runPeriod);
                _context.Devices.Update(device);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to turn on device");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
