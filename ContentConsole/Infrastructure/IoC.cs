using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;

namespace ContentConsole.Infrastructure
{
    public static class IoC
    {
        private static WindsorContainer Container { get; set; }
        
        static IoC()
        {
            Container = new WindsorContainer();
            Container.Install(new IoCInstaller());
        }


        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
        
    }
}
