using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Homes.RequestDTOs
{
    public class CreateHomeRequestDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string AppUserId { get; set; }
        public int[][] HouseMap { get; set; }
        public int MapRowCount { get; set; }
        public int MapColumnCount { get; set; }
        public List<CreateHomeDeviceDto> Devices { get; set; }
    }
}
