using Application.Models;
using Aspen.Application.Models;
using MediatR;

namespace Aspen.Application.Queries.GetAllCompany
{

    public class GetAllCompaniesQuery : IRequest<ResultViewModel<List<CompanyItemModel>>>
    {
        
    }

}
