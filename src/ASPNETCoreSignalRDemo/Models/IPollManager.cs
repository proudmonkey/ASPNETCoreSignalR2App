using System.Collections.Generic;
using ASPNETCoreSignalRDemo.Models.ViewModels;

namespace ASPNETCoreSignalRDemo.Models
{
    public interface IPollManager
    {
        bool AddPoll(AddPollViewModel pollModel);
        IEnumerable<PollDetailsViewModel> GetActivePoll();
        void UpdatePollOptionVotes(int pollOptionID);
        IEnumerable<VoteResultViewModel> GetPollVoteResults(int pollID);
    }
}
