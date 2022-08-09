using FluentValidation;

namespace Application.UseCase.UserOperation.Commands.Create
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.Email)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty()
                  .WithMessage("Email is invalid");
            RuleFor(x => x.Password)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty()
                  .WithMessage("Password is invalid");
            RuleFor(x => x.FirstName)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty()
                  .WithMessage("First name is invalid");
            RuleFor(x => x.LastName)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty()
                 .WithMessage("Last name is invalid");
            RuleFor(x => x.Birthday)
                  .Cascade(CascadeMode.Stop);
            RuleFor(x => x.Gender)
                 .Cascade(CascadeMode.Stop);
        }
    }
}
