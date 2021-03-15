using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Services.Students.Notifications
{
    public class LogDetailsNotification:INotification
    {
        public string Name { get; set; }
    }

    public class LogDetailsNotificationHandler : INotificationHandler<LogDetailsNotification>
    {
        public Task Handle(LogDetailsNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Logs written - {notification.Name}");
            return Task.CompletedTask;
        }
    }

    public class SmsDetailsNotificationHandler : INotificationHandler<LogDetailsNotification>
    {
        public Task Handle(LogDetailsNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Sms sent {notification.Name}");
            return Task.CompletedTask;
        }
    }

}
