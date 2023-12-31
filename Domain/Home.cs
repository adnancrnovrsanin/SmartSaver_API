namespace Domain
{
    public class Home
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public double Area { get; set; }
        public string AppUserId { get; set; }
        public ICollection<FieldRow> FieldRows { get; set; }
        public int MapRowCount { get; set; }
        public int MapColumnCount { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}