using System.ComponentModel.DataAnnotations;

namespace Messaging.Web.Models
{
    public class SmsModel
    {
        [Required(ErrorMessage = "To Number Required", AllowEmptyStrings = false)]
        [Phone]
        [Display(Name = "To Number")]
        public string To { get; set; }

        [Required(ErrorMessage = "Message Text Required", AllowEmptyStrings = false)]
        [Display(Name = "Message Text")]
        public string Text { get; set; }
    }
}
