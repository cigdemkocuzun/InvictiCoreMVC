using System.ComponentModel.DataAnnotations;

namespace MVCCoreTemplate.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
