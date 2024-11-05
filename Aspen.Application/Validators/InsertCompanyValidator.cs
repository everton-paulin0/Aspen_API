using Application.Models;
using Aspen.Application.Commands.InsertCompany;
using Aspen.Application.Models;
using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspen.Application.Validator
{
    public class InsertCompanyValidator :AbstractValidator<InsertCompanyCommand>
    {
        public InsertCompanyValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage("Preencher a Razão Social ").MinimumLength(2).MaximumLength(50);
            RuleFor(c => c.CompanyDocNumber).NotEmpty().WithMessage("Preencher o CNPJ ").MinimumLength(2).MaximumLength(14);
            RuleFor(c => c.CompanyAddress).NotEmpty().WithMessage("Preencher o Endereço").MinimumLength(2).MaximumLength(50);
            RuleFor(c => c.CompanyCity).NotEmpty().WithMessage("Preencher a Cidade").MaximumLength(30);
            RuleFor(c => c.CompanyState).NotEmpty().WithMessage("Preencher o Estados ").MaximumLength(2);
            RuleFor(c => c.CompanyEmail).NotEmpty().EmailAddress().WithMessage("E-mail Inválido");
            RuleFor(c => c.CompanyZipCode).NotEmpty().WithMessage("Preencher o CEP").MaximumLength(8);
        }
    }
}
