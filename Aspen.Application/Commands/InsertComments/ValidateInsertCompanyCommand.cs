using Aspen.Application.Commands.InsertCompany;
using Aspen.Application.Models;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Commands.InsertComments
{
    public class ValidateInsertCompanyCommand : IPipelineBehavior<InsertCompanyCommand, ResultViewModel<int>>
    {
        private readonly AspenDbContext _context;
        public ValidateInsertCompanyCommand(AspenDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertCompanyCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var userExists = _context.Users.Any(u => u.Id == request.IdUser);

            if (!userExists)
            {
                return ResultViewModel<int>.Error("Usuário Inválido");
            }

            return await next();
        }
    }
}
