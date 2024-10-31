using Application.Models;
using Aspen.Application.Models;
using Aspen.Application.Queries.GetAllCompany;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Queries.GetByIdCompany
{
    public class GetCompanyByIdQuery : IRequest<ResultViewModel<CompanyViewModel>>
    {
        public GetCompanyByIdQuery()
        {
            Id = Id;
        }
        public int Id { get; set; }        
    }

    public class GetCompányByIdHandler : IRequestHandler<GetCompanyByIdQuery, ResultViewModel<CompanyViewModel>>
    {
        private readonly AspenDbContext _context;
        public GetCompányByIdHandler(AspenDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<CompanyViewModel>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {

            var company = await _context.Companies.SingleOrDefaultAsync(c => c.Id == request.Id);

            if (company == null)
            {
                return ResultViewModel<CompanyViewModel>.Error("Projeto Não Encontrado");
            }

            var model = CompanyViewModel.FromEntity(company);

            return ResultViewModel<CompanyViewModel>.Sucess(model);
        }
    }
}
