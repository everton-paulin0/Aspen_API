using Application.Models;
using Aspen.Application.Models;
using Core.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Commands.InsertComments
{
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly AspenDbContext _context;
        public InsertCommentHandler(AspenDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(c => c.Id == request.IdUser);

            if (company == null)
            {
                return ResultViewModel<CreateCompanyCommentInputModel>.Error("Projeto Não Encontrado");
            }

            var comment = new CompanyComment(request.Content, request.IdUser, request.IdCompany);

            await _context.CompanyComments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}
