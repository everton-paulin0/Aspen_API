using Application.Models;
using Aspen.Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aspen.Application.Queries.GetAllCompany
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, ResultViewModel<List<CompanyItemModel>>>
    {
        private readonly AspenDbContext _context;
        public GetAllCompaniesHandler(AspenDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<CompanyItemModel>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _context.Companies.Where(c => !c.IsDeleted).ToListAsync();

            var model = companies.Select(CompanyItemModel.FromEntity).ToList();

            return ResultViewModel<List<CompanyItemModel>>.Sucess(model);
        }
    }

}
