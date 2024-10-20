using Application.Models;
using Aspen.Application.Models;
using Infrastructure.Persistence;
using System;


namespace Aspen.Application.Services.Interfaces
{
    public interface ICompanyService
    {
        ResultViewModel<List<CompanyItemModel>> GetAll(string search = "");

        ResultViewModel<CompanyViewModel> GetById(int id);

        ResultViewModel<int> Insert(CreateCompanyInputModel model);

        ResultViewModel Update(UpdateCompanyInputModel model);

        ResultViewModel Delete(int id);

        ResultViewModel InsertComments(int id, CreateCompanyCommentInputModel model);

    }


}
