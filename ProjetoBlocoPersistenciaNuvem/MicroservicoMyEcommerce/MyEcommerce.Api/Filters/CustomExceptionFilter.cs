using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyEcommerce.CrossCutting.Exceptions;
using System.Net;

namespace MyEcommerce.Api.Filters;

public class CustomExceptionFilterAtribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);
        if (context.Exception is IdNotFoundException)
        {
            ObjectResult result = new(context.Exception.Message)
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
            context.Result = result;
        }
        if (context.Exception is ValidationException)
        {
            ObjectResult result = new(context.Exception.Message)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            context.Result = result;
        }
        if (context.Exception is NotImplementedException)
        {
            ObjectResult result = new("Funcionalidade ainda não implementada :(")
            {
                StatusCode = (int)HttpStatusCode.NotImplemented
            };
            context.Result = result;
        }
    }
}
