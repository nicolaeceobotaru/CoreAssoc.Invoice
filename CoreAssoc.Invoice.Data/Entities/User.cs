namespace CoreAssoc.Invoice.Data.Entities
{
    public class User : BaseIdEntity
    {
        public UserRole Role { get; set; }
        public string ApiKey { get; set; }
    }
}