using Microsoft.AspNetCore.SignalR;

namespace WP.Hubs
{
    public class ViewHub : Hub
    {
        public int ViewCount { get; set; } = 0;
        public async Task NotifyWatching()
        {
            ViewCount++;
            await Clients.All.SendAsync("viewCountUpdate", ViewCount);
        }
    }
}
