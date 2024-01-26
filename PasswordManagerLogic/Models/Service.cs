namespace PasswordManagerLogic.Models
{
    public class Service: IPrintInfoString
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Data> Data { get; set; } = new();

        public string PrintInfo() {
            return Name;
        }
    }
}
