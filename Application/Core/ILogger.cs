using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface ILogger
    {
        public void Log(IAppActor actor,IUseCase useCase, object objInput, bool isSuccesffull);
    }
}
