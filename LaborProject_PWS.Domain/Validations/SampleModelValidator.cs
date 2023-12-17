using FluentValidation;
using LaborProject_PWS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProject_PWS.Domain.Validations
{
    public class SampleModelValidator : AbstractValidator<SampleModel>
    {
        public SampleModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18, 100).When(x => x.Age.HasValue);
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\+?[0-9]{3}-?[0-9]{6,12}$");
            RuleFor(x => x.DateOfBirth).NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.Salary).GreaterThan(0).When(x => x.Salary.HasValue);
            RuleFor(x => x.Department).NotEmpty();
            RuleFor(x => x.Role).NotEmpty();
        }
    }
}
