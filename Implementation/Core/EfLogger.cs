using Application.Core;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Implementation.Core
{
    public class EfLogger : ILogger
    {
        private readonly Context context;
        private readonly EFLoggerValidator validator;
        public EfLogger(Context context, EFLoggerValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public void Log(IAppActor actor, IUseCase useCase, object objInput, bool isSuccesffull)
        {
            if (actor.Id != -1) 
            {
                this.validator.ValidateAndThrow(useCase);

                var Input = JsonSerializer.Serialize(objInput);

                var newObject = new TraceObjects()
                {
                    UseCaseId = useCase.Id_UseCase,
                    UserIdentity = actor.Identity,
                    UserId = actor.Id,
                    InputParameters = Input,
                    Response = isSuccesffull ? "Success" : "Error",
                    NameUseCase = useCase.Name_UseCase,
                };

                this.context.TraceObjects.Add(newObject);
                this.context.SaveChanges();
            }
        }
    }
}
