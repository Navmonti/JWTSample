using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTSample.Domain.Dtos
{
    public class LoginDto
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; } = String.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = String.Empty;
    }
}
