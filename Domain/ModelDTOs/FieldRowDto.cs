using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class FieldRowDto
    {
        public Guid Id { get; set; }
        public Guid HomeId { get; set; }
        public ICollection<FieldDto> Fields { get; set; }
    }
}
