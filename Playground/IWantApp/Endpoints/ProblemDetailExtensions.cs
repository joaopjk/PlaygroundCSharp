using Flunt.Notifications;

namespace IWantApp.Endpoints
{
    public static class ProblemDetailExtensions
    {
        public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
        {
            return notifications
                    .GroupBy(_ => _.Key)
                    .ToDictionary(_ => _.Key, _ =>
                        _.Select(_ => _.Message).ToArray());
        }
    }
}
