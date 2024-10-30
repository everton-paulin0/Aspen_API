using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Core.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAll();
        Task<Company> GetById(int id);
        Task<Company> GetdetailById(int id);
        Task<int> Add(Company company);
        Task Update(Company company);
        Task AddComment(CompanyComment comment);
        Task<bool>Exists(int id);
    }
}
