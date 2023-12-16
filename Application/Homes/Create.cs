using Application.Core;
using Application.Homes.RequestDTOs;
using AutoMapper;
using Domain;
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
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateHomeRequestDto Home { get; set; }
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
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Home.AppUserId);

                if (user == null) return Result<Unit>.Failure("User not found");

                var devices = new List<Device>();

                var home = new Home
                {
                    Id = Guid.NewGuid(),
                    Name = request.Home.Name,
                    Address = request.Home.Address,
                    City = request.Home.City,
                    State = request.Home.State,
                    ZipCode = request.Home.ZipCode,
                    AppUserId = request.Home.AppUserId,
                    Devices = new List<Device>(),
                    FieldRows = new List<FieldRow>(),
                    MapRowCount = request.Home.MapRowCount,
                    MapColumnCount = request.Home.MapColumnCount,
                };

                foreach (var device in request.Home.Devices)
                {
                    var newDevice = new Device
                    {
                        Id = Guid.NewGuid(),
                        Name = device.Name,
                        Type = device.Type,
                        Manufacturer = device.Manufacturer,
                        ModelNumber = device.ModelNumber,
                        PowerUsage = device.PowerUsage,
                        Row = device.Coordinates[0],
                        Col = device.Coordinates[1],
                        IsOn = false,
                        HomeId = home.Id
                    };
                    devices.Add(newDevice);
                    home.Devices.Add(newDevice);
                }

                for (int i = 0; i < request.Home.MapRowCount; i++)
                {
                    var fieldRow = new FieldRow
                    {
                        Id = Guid.NewGuid(),
                        HomeId = home.Id,
                        Fields = new List<Field>()
                    };
                    for (int j = 0; j < request.Home.MapColumnCount; j++)
                    {
                        var deviceCheck = devices.SingleOrDefault(d => d.Row == i && d.Col == j);
                        var field = new Field
                        {
                            Coordinates = [i, j],
                            DeviceId = deviceCheck?.Id,
                            FieldRowId = fieldRow.Id,
                            Value = request.Home.HouseMap[i][j],
                        };
                        fieldRow.Fields.Add(field);
                    }
                    home.FieldRows.Add(fieldRow);
                }

                _context.Homes.Add(home);
                _context.Devices.AddRange(devices);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create home");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
