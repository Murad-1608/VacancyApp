using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.SubCategory).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.Education).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.MinSalary).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.MaxSalary).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.Requirements).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.JobInformation).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.MinAge).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.MaxAge).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş ola bilməz");
        }
    }
}
