using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.Forms
{
    public class EmailFormModel
    {
        [Required(ErrorMessage ="Please provide a name so that i can know who you are.")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please provide an email so i can reach out if necessary.")]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please type a message so that i know what this contact is about.")]
        [Display(Name="Message")]
        public string Message { get; set; }

        public string Phone { get; set; }
    }
}