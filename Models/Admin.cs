namespace MedicalStore.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string password { get; set; }
        public string Password { get; internal set; }
        public string Username { get; internal set; }
    }
}
