using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IUseCase
    {
        public int Id_UseCase { get; }
        public string Name_UseCase { get; }

    }


    public interface IQuery<search,resoult> : IUseCase
    {
        public resoult Query(search search);
    }

    public interface ICommand<request> : IUseCase
    {
        public void Execute(request request);
    }

}
