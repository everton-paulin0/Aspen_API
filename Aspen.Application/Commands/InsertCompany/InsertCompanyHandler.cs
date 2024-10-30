using Aspen.Application.Models;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Commands.InsertCompany
{
    public class InsertCompanyHandler : IRequestHandler<InsertCompanyCommand, ResultViewModel<int>>
    {
        private readonly AspenDbContext _context;
        public InsertCompanyHandler(AspenDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = request.ToEntity();

            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Sucess(company.Id);
        }
    }
}
