using System.Collections.Generic;

namespace ASPNETCoreSignalRDemo.Models.ViewModels
{
    public class PollDetailsViewModel
    {
        public int PollID { get; set; }
        public string Question { get; set; }
        public IEnumerable<DB.PollOption> PollOption { get; set; }
    }
}
