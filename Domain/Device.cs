namespace Domain
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }
        public double PowerUsage { get; set; }
    }
}