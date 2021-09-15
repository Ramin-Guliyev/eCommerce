using FluentValidation;

namespace Application.Basket.Queries.GetUserBasketByEmail
{
    public class GetUserBasketByEmailQueryValidator : AbstractValidator<GetUserBasketByEmailQuery>
    {
        public GetUserBasketByEmailQueryValidator()
        {
            RuleFor(x => x.email)
                .NotNull();
        }
    }
}
