using Application.Models;
using Aspen.Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Aspen.Application.Queries.GetByIdCompany
{
    public class GetCompanyByIdQuery : IRequest<ResultViewModel<CompanyViewModel>>
    {
        public GetCompanyByIdQuery(int id)
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

            var company = await _context.Companies.Include(c => c.Comments).Include(c => c.IdUser).SingleOrDefaultAsync(c => c.Id == request.Id);

            if (company == null)
            {
                return ResultViewModel<CompanyViewModel>.Error("Projeto Não Encontrado");
            }

            var model = CompanyViewModel.FromEntity(company);

            return ResultViewModel<CompanyViewModel>.Sucess(model);
        }
    }
}
