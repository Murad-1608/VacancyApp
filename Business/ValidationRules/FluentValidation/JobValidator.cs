using Entity.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class JobValidator : AbstractValidator<AddJobDto>
    {
        public JobValidator()
        {
            
        }
    }
}
