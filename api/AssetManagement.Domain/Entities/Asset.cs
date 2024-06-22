namespace AssetManagement.Domain.Entities
{
    public class Asset
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? EmployeeId { get; set; }
    }
}
