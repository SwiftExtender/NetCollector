using System.ComponentModel.DataAnnotations;

namespace NetFighter.RequestModels
{
    public class AuthModel
    {
        [Required]
        public string UserName;
        [Required]
        [DataType(DataType.Password)]
        public string Password;
        internal bool RememberMe;
    }

    public class ForgetPassword
    {
        public string Email;
    }
}
