using Aspen.Application.Models;
using Aspen.Application.Notification.CompanyCreated;
using Infrastructure.Persistence;
using MediatR;

namespace Aspen.Application.Commands.InsertCompany
{
    public class InsertCompanyHandler : IRequestHandler<InsertCompanyCommand, ResultViewModel<int>>
    {
        private readonly AspenDbContext _context;
        private readonly IMediator _mediator;
        public InsertCompanyHandler(AspenDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<ResultViewModel<int>> Handle(InsertCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = request.ToEntity();

            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();

            var companyCreated = new CompanyCreatedNotification(company.Id, company.CompanyName);
            await _mediator.Publish(companyCreated);

            return ResultViewModel<int>.Sucess(company.Id);
        }
    }
}
