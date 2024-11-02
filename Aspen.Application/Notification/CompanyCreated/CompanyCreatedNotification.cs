﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Notification.CompanyCreated
{
    public class CompanyCreatedNotification : INotification
    {

        public CompanyCreatedNotification(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
