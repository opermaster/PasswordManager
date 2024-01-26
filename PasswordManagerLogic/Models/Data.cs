namespace PasswordManagerLogic.Models
{
    public class Data
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string? FirstField { get; set; }
        public string? Password { get; set; }

        public Service? Service { get; set; }
    }
}
