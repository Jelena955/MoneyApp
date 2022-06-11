using Application.Dto.UsersDto;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateNewUserValidation : AbstractValidator<NewUserDto>
    {
        public CreateNewUserValidation(Context context, ImageValidation imageValidator)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is manditory").MaximumLength(20).WithMessage("Maximum length is 20 characters").Matches(@"^[A-Z][a-z]{1,19}$").WithMessage("Name must begin with Capital letter");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is manditory").MaximumLength(20).WithMessage("Maximum length is 20 characters").Matches(@"^[A-Z][a-z]{1,19}$").WithMessage("Last name must begin with Capital letter");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is manditory").MaximumLength(20).WithMessage("Maximum length is 20 characters");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary is manditory").GreaterThan(0).WithMessage("Salary must be greater than 0");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Salary is manditory").MaximumLength(30).WithMessage("Maximum length is 30 characters").MinimumLength(5).WithMessage("Minimum length is 5 characters").Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{5,30}$").WithMessage("Password need atleast 1 uppercase letter, 1 lowercase letter and one number");
            RuleFor(x => x.IdBaseCurrency).NotEmpty().WithMessage("Currency is manditory").Must(x => context.Currencys.Any(y => y.Id == x)).WithMessage("Specified currency does not exist");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is manditory").EmailAddress().WithMessage("Email address is not valid");
            RuleFor(x => x.DayOfSalary).NotEmpty().WithMessage("Day of salary is manditory").GreaterThan(0).WithMessage("Must be gerater than 0").LessThan(31).WithMessage("Can't go beyond 31.");

            RuleFor(x => x.Picture).SetValidator(imageValidator);

        }
    }
}
