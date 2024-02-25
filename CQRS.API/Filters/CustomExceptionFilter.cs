using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CQRS.API.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FluentValidation.ValidationException validationException)
        {
            var errors = validationException.Errors
                .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

            var result = new ObjectResult(new { Errors = errors })
            {
                StatusCode = 400 // Bad request
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
        else if (context.Exception is ArgumentException || context.Exception is KeyNotFoundException)
        {
            // Tratar erro 404 (Recurso não encontrado)
            context.Result = new NotFoundObjectResult(new { Error = "Resource not found" });
            context.ExceptionHandled = true;
        }
        else if (context.Exception is HttpRequestException || context.Exception is InvalidOperationException)
        {
            // Tratar erro 500 (Erro interno do servidor)
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            context.ExceptionHandled = true;
        }

    }
}
