using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ContentConsole.Fakes;
using ContentConsole.Words;
using Domain;

namespace ContentConsole.Infrastructure
{
    public class IoCInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<Runner>());
            container.Register(Component.For<IRepository<Word>>().ImplementedBy<FakeRepository<Word>>());
            container.Register(Component.For<IWordsFactory>().ImplementedBy<WordsFactory>());
            container.Register(Component.For<IUserProfile>().ImplementedBy<FakeUserProfile>());
            container.Register(Component.For<IWordsService>().ImplementedBy<WordsService>());
        }
    }
}
