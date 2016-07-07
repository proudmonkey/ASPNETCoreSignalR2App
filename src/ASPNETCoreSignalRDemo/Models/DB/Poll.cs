using System.Collections.Generic;

namespace ASPNETCoreSignalRDemo.Models.DB
{
    public partial class Poll
    {
        public Poll()
        {
            PollOption = new HashSet<PollOption>();
        }

        public int PollId { get; set; }
        public string Question { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PollOption> PollOption { get; set; }
    }
}
