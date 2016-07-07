using Microsoft.AspNet.SignalR;

namespace ASPNETCoreSignalRDemo.Hubs
{
    public class PollHub: Hub
    {
        public static void FetchPoll()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<PollHub>();
            context.Clients.All.displayPoll();
        }
    }
}
