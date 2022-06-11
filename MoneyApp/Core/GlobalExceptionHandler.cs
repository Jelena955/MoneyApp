using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Application.CustomExceptions;

namespace MoneyApp.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate nextTask;

        public GlobalExceptionHandler(RequestDelegate NextTask)
        {
            this.nextTask = NextTask;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await this.nextTask(httpContext);
            }
            catch (System.Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                switch (ex)
                {
                    case UserAlredyActiveException obj:
                        statusCode = StatusCodes.Status400BadRequest;
                        response = new
                        {
                            message = obj.Message
                        };
                        break;
                    case FailedToSendEmailException obj:
                        statusCode = StatusCodes.Status503ServiceUnavailable;
                        response = new
                        {
                            message = obj.Message,
                            ZaLukuGreska = "Iako se mail nije poslao user je kreiran, tako da se moze rucno aktivirati korisnik"
                        };
                        break;
                    case NegativeNumberException obj:
                        statusCode = StatusCodes.Status400BadRequest;
                        response = new
                        {
                            message = obj.Message
                        };
                        break;
                    case ValidationException obj:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = obj.Errors.Select(x => new
                        {
                            x.PropertyName,
                            x.ErrorMessage
                        });
                        break;
                    case ConflictException obj:
                        statusCode = StatusCodes.Status409Conflict;
                        response = new
                        {
                            message = obj.Message
                        };
                        break;
                    case DoesNotExistException obj:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = obj.Message
                        };
                        break;
                    case UserNotFoundException obj:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = obj.Message
                        };
                        break;
                    case UnAuthorizedException obj:
                        statusCode = StatusCodes.Status401Unauthorized;
                        response = new
                        {
                            message = obj.Message
                        };
                        break;
                }
                httpContext.Response.StatusCode = statusCode;
                if (response != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }
                await Task.FromResult(httpContext.Response);
            }
        }
    }
}
