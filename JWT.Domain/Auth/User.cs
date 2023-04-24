using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSWSample.Domain.Auth
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get; set; }
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Salt { get; set; } = "";
        public string? Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
    }
}
