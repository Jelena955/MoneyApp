using Application.Core;
using Application.Dto.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UseCase
{
    public interface IUpdateUseCase : ICommand<UpdateUseCaseDto>
    {
    }
}
