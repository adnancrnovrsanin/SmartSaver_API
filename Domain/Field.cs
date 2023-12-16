namespace Domain
{
    public class Field
    {
        public Guid Id { get; set; }
        public int[] Coordinates { get; set; }
        public int Value { get; set; }
        public Guid? DeviceId { get; set; }
        public Guid FieldRowId { get; set; }
        public FieldRow FieldRow { get; set; }
        public Device Device { get; set; }
    }
}
