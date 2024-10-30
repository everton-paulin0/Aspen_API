using Aspen.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
