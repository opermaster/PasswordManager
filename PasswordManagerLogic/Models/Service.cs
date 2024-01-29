namespace PasswordManagerLogic.Models
{
    /// <summary>
    /// Service class that implements interface IPrintInfoString.
    /// Has fields like Id, Name
    /// List of Data that it connected with
    /// </summary>
    public class Service: IPrintInfoString
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Data> Data { get; set; } = new();
        /// <summary>
        /// Returns Service as String
        /// </summary>
        /// <returns></returns>
        public string PrintInfo() {
            return Name?? "Undefined service";
        }
        /// <summary>
        /// Returns Service as String
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return Name?? "Undefined service";
        }
    }
}
