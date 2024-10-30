using Application.Models;
using Aspen.Application.Models;
using Azure.Core;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Commands.DeleteCompany
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, ResultViewModel>
    {
        private readonly AspenDbContext _context;
        public DeleteCompanyHandler(AspenDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(c => c.Id == request.Id);

            if (company == null)
            {
                return ResultViewModel<CompanyViewModel>.Error("Projeto Não Encontrado");
            }

            company.SetAsDeleted();
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}
