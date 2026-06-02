namespace BlazorApps.Services;

public class NotificationService
{
    private readonly NotificationConfig _config;

    public NotificationService(NotificationConfig config)
    {
        _config = config;
    }

    public Task<List<NotificationItem>> GetNotificationsAsync(int? count = null)
    {
        int n = count ?? _config.DefaultNumberOfNotifications;
        var random = new Random();
        var types = new[] { "Info", "Warning", "Error", "Success" };
        var messages = new[]
        {
            "Server backup completed successfully",
            "New user registration pending approval",
            "Database connection pool at 80% capacity",
            "Scheduled maintenance in 2 hours",
            "Failed login attempt detected",
            "New comment on your post",
            "System update available",
            "API rate limit approaching",
            "Payment received from client",
            "Report generation completed"
        };

        var notifications = Enumerable.Range(1, n)
            .Select(i => new NotificationItem
            {
                Id = i,
                Message = messages[(i - 1) % messages.Length],
                Type = types[random.Next(types.Length)],
                Time = DateTime.Now.AddMinutes(-random.Next(1, 60))
            })
            .ToList();

        return Task.FromResult(notifications);
    }

    public class NotificationItem
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = "Info";
        public DateTime Time { get; set; }
    }
}
