namespace Application.Homes.RequestDTOs
{
    public class CreateHomeDeviceDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }
        public int PowerUsage { get; set; }
        public int[] Coordinates { get; set; }
    }
}
