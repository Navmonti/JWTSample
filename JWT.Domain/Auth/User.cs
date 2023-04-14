using System.ComponentModel.DataAnnotations; 

namespace JSWSample.Domain.Auth
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}
