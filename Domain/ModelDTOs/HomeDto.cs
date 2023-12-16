using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class HomeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public double Area { get; set; }
        public string AppUserId { get; set; }
        public ICollection<FieldRowDto> FieldRows { get; set; }
        public int MapRowCount { get; set; }
        public int MapColumnCount { get; set; }
        public ICollection<DeviceDto> Devices { get; set; }
    }
}
