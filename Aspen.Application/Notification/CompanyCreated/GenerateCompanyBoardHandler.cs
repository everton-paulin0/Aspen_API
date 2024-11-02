using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Notification.CompanyCreated
{
    public class GenerateCompanyBoardHandler : INotificationHandler<CompanyCreatedNotification>
    {
        public Task Handle(CompanyCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Criando painel para o projeto{notification.Title}");

            return Task.CompletedTask;
        }
    }
}
