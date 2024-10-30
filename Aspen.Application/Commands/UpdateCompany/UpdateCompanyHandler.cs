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

namespace Aspen.Application.Commands.UpdateCompany
{
    
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, ResultViewModel>
    {
        private readonly AspenDbContext _context;
        public UpdateCompanyHandler(AspenDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(c => c.Id == request.IdCompany);

            if (company == null)
            {
                return ResultViewModel.Error("Projeto Não Encontrado");
            }

            company.Update(request.CompanyName, request.CompanyDocNumber, request.CompanyAddress, request.CompanyCity, request.CompanyState, request.CompanyZipCode, request.CompanyEmail, request.IdUser, request.IdContactPerson);

            _context.Companies.Update(company);

            await _context.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}
