using Application.Models;
using Aspen.Application.Commands.InsertCompany;
using Aspen.Application.Models;
using Aspen.Application.Services.Interfaces;
using Core.Entities;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;


namespace Aspen.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AspenDbContext _context;
        public CompanyService(AspenDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
            {
                return ResultViewModel<CompanyViewModel>.Error("Projeto Não Encontrado");
            }

            company.SetAsDeleted();
            _context.Companies.Update(company);
            _context.SaveChanges();

            return ResultViewModel.Sucess();
        }

        public ResultViewModel<List<CompanyItemModel>> GetAll(string search = "")
        {
            var companies = _context.Companies.Where(c => !c.IsDeleted).ToList();

            var model = companies.Select(CompanyItemModel.FromEntity).ToList();

            return ResultViewModel<List<CompanyItemModel>>.Sucess(model);
        }

        public ResultViewModel<CompanyViewModel> GetById(int id)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
            {
                return ResultViewModel<CompanyViewModel>.Error("Projeto Não Encontrado");
            }

            var model = CompanyViewModel.FromEntity(company);

            return ResultViewModel<CompanyViewModel>.Sucess(model);
        }

        public ResultViewModel<int> Insert(CreateCompanyInputModel model)
        {
            var company = model.ToEntity();

            _context.Companies.Add(company);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(company.Id);
        }

        public ResultViewModel InsertComments(int id, CreateCompanyCommentInputModel model)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
            {
                return ResultViewModel<CreateCompanyCommentInputModel>.Error("Projeto Não Encontrado");
            }

            var comment = new CompanyComment(model.Content, model.IdUser, model.IdCompany);

            _context.CompanyComments.Add(comment);
            _context.SaveChanges();

            return ResultViewModel.Sucess();
        }

        public ResultViewModel Update(UpdateCompanyInputModel model)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == model.IdCompany);

            if (company == null)
            {
                return ResultViewModel.Error("Projeto Não Encontrado");
            }

            company.Update(model.CompanyName, model.CompanyDocNumber, model.CompanyAddress, model.CompanyCity, model.CompanyState, model.CompanyZipCode, model.CompanyEmail, model.IdUser, model.IdContactPerson);

            _context.Companies.Update(company);

            _context.SaveChanges();

            return ResultViewModel.Sucess();

        }

        
    }
}
