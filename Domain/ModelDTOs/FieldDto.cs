namespace Domain.ModelDTOs
{
    public class FieldDto
    {
        public Guid Id { get; set; }
        public int[] Coordinates { get; set; }
        public Guid? DeviceId { get; set; }
        public Guid FieldRowId { get; set; }
    }
}
