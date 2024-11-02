using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Notification.CompanyCreated
{
    public class UserNotificationHandler : INotificationHandler<CompanyCreatedNotification>
    {
        public Task Handle(CompanyCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notificação referente a Empresa {notification.Title}");

            return Task.CompletedTask;
        }
    }
}
