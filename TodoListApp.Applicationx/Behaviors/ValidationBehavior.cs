using FluentValidation;
using MediatR;

namespace TodoListApp.Applicationx.Behaviors
{
    public class ValidationBehavior<TRequest, TResoponse> : IPipelineBehavior<TRequest, TResoponse>
        where TRequest : IRequest<TResoponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResoponse> Handle(TRequest request, RequestHandlerDelegate<TResoponse> next, CancellationToken cancellationToken)
        {
            //validamos si es que existe alguna validacion
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                //ejecutamos las validaciones
                var validationResults =
                    await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));


                //verificamos que tenga errores
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                    throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
