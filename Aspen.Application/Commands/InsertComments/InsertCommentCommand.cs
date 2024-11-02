using Aspen.Application.Models;
using MediatR;

namespace Aspen.Application.Commands.InsertComments
{
    public class InsertCommentCommand : IRequest<ResultViewModel>
    {
        public string Content { get; set; }
        public int IdCompany { get; set; }
        public int IdUser { get; set; }
    }
}
