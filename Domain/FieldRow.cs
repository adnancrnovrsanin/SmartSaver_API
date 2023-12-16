namespace Domain
{
    public class FieldRow
    {
        public Guid Id { get; set; }
        public Guid HomeId { get; set; }
        public Home Home { get; set; }
        public ICollection<Field> Fields { get; set; }
    }
}
