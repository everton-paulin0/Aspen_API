using Aspen.Application.Models;
using MediatR;


namespace Aspen.Application.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<ResultViewModel>
    {
        public DeleteCompanyCommand(int id)
        {
            Id = id; 
        }
        public int Id { get; set; }
    }
}
