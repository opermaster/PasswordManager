namespace PasswordManagerLogic.Models
{
    /// <summary>
    /// Data class that implements interface IPrintInfoString.
    /// Has fields like Id, Id of service that it is connected, FirstField(Information that used for logging),
    /// Password, Service
    /// </summary>
    public class Data: IPrintInfoString
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string? FirstField { get; set; }
        public string? Password { get; set; }

        public Service? Service { get; set; }
        /// <summary>
        /// Returns Data as String
        /// </summary>
        /// <returns></returns>
        public string PrintInfo() {
            return Id+" "+FirstField + " " +Password;
        }
    }
}
