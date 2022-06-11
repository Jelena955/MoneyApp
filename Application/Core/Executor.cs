using Application.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Core
{
    public class Executor
    {
        private readonly ILogger loger;
        private IAppActor actor;

        public Executor(ILogger loger, IAppActor actor)
        {
            this.loger = loger;
            this.actor = actor;
        }

        public resoult ExecuteQuery<search,resoult>(IQuery<search,resoult> query, search searchObj)
        {
            //pre processing
            if (!this.actor.AllowedActions.Contains(query.Id_UseCase))
            {
                throw new UnAuthorizedException("You are not allowed to execute this action");
            }

            this.loger.Log(this.actor, query, searchObj, true);

            var queryResoult = query.Query(searchObj);

            //post processing

            return queryResoult;
        }

        public void ExecuteCommand<request>(ICommand<request>command,request requestObj)
        {
            //pre processing
            if (!this.actor.AllowedActions.Contains(command.Id_UseCase))
            {
                throw new UnAuthorizedException("You are not allowed to execute this action");
            }

            this.loger.Log(this.actor, command, requestObj, true);

            command.Execute(requestObj);

            //post processing

        }
    }
}
