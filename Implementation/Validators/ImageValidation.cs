using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class ImageValidation : AbstractValidator<IFormFile>
    {
        public ImageValidation()
        {
            RuleFor(x => x.ContentType).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png")).WithMessage("Picture format is not good, supported file types: jpg, jpeg or png");
            RuleFor(x => x.Length).LessThanOrEqualTo(50000000).WithMessage("Image is too large");
        }
    }
}
