namespace StudentManagement.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string RegNumber { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
