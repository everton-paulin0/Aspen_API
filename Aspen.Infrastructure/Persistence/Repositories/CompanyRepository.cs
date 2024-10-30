using Aspen.Core.Repositories.Interfaces;
using Core.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        //private readonly AspenDbContext _context;
        //private readonly ICompanyService _service;
        //public CompanyController(AspenDbContext context, ICompanyService service)
        //{
            //_context = context;
            //_service = service;
        //}
        public async Task<int> Add(Company company)
        {
            //await _context.Companies.Add(company);
            //_context.SaveChanges();

            return company.Id;
        }

        public Task AddComment(CompanyComment comment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetdetailById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
