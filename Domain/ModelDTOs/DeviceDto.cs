using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class DeviceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }    
        public string ModelNumber { get; set; }
        public double PowerUsage { get; set; }
        public bool IsOn { get; set; }
        public Guid HomeId { get; set; }
    }
}
