using Aspen.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Commands.InsertComments
{
    public class InsertCommentCommand : IRequest<ResultViewModel>
    {
        public string Content { get; set; }
        public int IdCompany { get; set; }
        public int IdUser { get; set; }
    }
}
