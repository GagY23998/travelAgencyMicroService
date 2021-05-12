using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Application.Validators
{
    public class ValidatePipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidatePipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationContext = new ValidationContext<TRequest>(request);
            var failures = validators.Select(_ => _.Validate(validationContext))
                .SelectMany(_ => _.Errors)
                .Where(x => x != null);
            if (failures.Any())
            {
                throw new Exception("Request doesn't fullfill the requirements");
            }
           return next();
        }
    }
}
