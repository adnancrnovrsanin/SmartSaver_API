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
        public bool IsOn { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public Guid HomeId { get; set; }
        public ICollection<RunPeriod> RunPeriods { get; set; }
        public Home Home { get; set; }
    }
}