using FluentValidation;
using MediatR;

public  class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        if(_validators.Any())
        {

            var context=new ValidationContext<TRequest>(request);
            var results = await Task.WhenAll(_validators.Select(v=>v.ValidateAsync(context,cancellationToken)));
            var failures=results.SelectMany(e=>e.Errors).Where(r=>r!=null).ToList();

            if(failures.Any())
            {

                

                throw new ValidationException("Validation Errors",failures);
            }
        }


        return await next();

    }


}