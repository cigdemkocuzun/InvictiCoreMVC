using System.ComponentModel.DataAnnotations;


namespace MVCCoreTemplate.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
