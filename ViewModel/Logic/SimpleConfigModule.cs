using Model;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.DataAccessLayer;

namespace ViewModel.Logic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IRepository<Student>>().To<EntityRepository<Student>>().InSingletonScope();
            Bind<IRepository<Student>>().To<DapperRepository<Student>>().InSingletonScope();
        }
    }
}
