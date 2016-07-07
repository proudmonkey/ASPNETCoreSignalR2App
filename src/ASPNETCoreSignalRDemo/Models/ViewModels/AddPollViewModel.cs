using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreSignalRDemo.Models.ViewModels
{
    public class AddPollViewModel
    {
        [Required(ErrorMessage = "Question is required.")]   
        public string Question { get; set; }
        [Required(ErrorMessage = "Answer is required.")]
        public string Answer { get; set; }    
    }
}
