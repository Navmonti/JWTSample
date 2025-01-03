namespace JWTSample.Api.ViewModel
{
    /// <summary>
    /// SignUp Model
    /// </summary>
    public class SignupModel
    {
        /// <summary>
        /// Firstname
        /// </summary>    
        public string Firstname { get; set; } = String.Empty;

        /// <summary>
        /// Lastname
        /// </summary>
        public string Lastname { get; set; } = String.Empty;

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; } = String.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = String.Empty;

        /// <summary>
        /// Confirm Password
        /// </summary>
        public string ConfirmPassword { get; set; } = String.Empty;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = String.Empty;

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; } = String.Empty;
    }
}
