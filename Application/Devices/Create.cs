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
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public DeviceDto Device { get; set; }
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
                var home = await _context.Homes.FirstOrDefaultAsync(x => x.Id == request.Device.HomeId);

                if (home == null) return Result<Unit>.Failure("Home not found");

                var device = new Device
                {
                    Name = request.Device.Name,
                    Type = request.Device.Type,
                    Manufacturer = request.Device.Manufacturer,
                    ModelNumber = request.Device.ModelNumber,
                    PowerUsage = request.Device.PowerUsage,
                    IsOn = false
                };
                if (home.Devices == null) home.Devices = new List<Device>();
                home.Devices.Add(device);

                _context.Devices.Add(device);
                _context.Homes.Update(home);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create home");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
