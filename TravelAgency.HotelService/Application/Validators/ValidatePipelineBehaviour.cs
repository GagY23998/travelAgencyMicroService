using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Application.Validators
{
    public class ValidatePipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public ValidatePipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            Validators = validators;
        }

        public IEnumerable<IValidator<TRequest>> Validators { get; }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var cxt = new ValidationContext<TRequest>(request);

            var result= Validators.Select(_ => _.Validate(cxt)).SelectMany(_=>_.Errors).Where(it => it != null);

            if (result != null)
            {
                throw new Exception();
            }
            return next();
        }
    }
}
