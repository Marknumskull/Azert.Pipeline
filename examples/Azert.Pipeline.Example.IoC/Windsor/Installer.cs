using System;
using Azert.Pipeline.Contracts;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Azert.Pipeline.Example.IoC.Windsor {
    public class Installer : IWindsorInstaller {

        public void Install(IWindsorContainer container, IConfigurationStore store) {

            container.Register(

                //Set all as singletons
                Component.For<IPipeline>().ImplementedBy<Pipleline.Sync.Pipeline>(),
                Classes.FromAssemblyInDirectory(new AssemblyFilter(Environment.CurrentDirectory))
                    .BasedOn<IFilter>()
                    .WithServiceBase()
                );

        }
    }
}