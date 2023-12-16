using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RunPeriod
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double PowerSpent { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
