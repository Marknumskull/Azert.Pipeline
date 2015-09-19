using System;
using System.Linq;
using Azert.Pipeline.Contracts;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Azert.Pipeline.Example.IoC {
    /// <summary>
    /// Run this example program from a cmd window and enter some text string ie "Hi there"
    /// the pipeline will then execute each filter an apply some operations to the string
    /// which will be shown in the console window.
    /// 
    /// This shows how you can use DI and an IoC container to load and order all filters
    /// based on their order property.
    /// 
    /// This method gives tremendous flexibility and would allow new filters to be dropped
    /// into the bin folder negating the need to recompile the application.
    /// 
    /// It does however remove the immediate glancable ordering that is evident in an explit registration
    /// and there is more of a chance you could apply an incorrect ordering
    /// (this is shown in the ExplictRegistration example
    /// 
    /// </summary>
    class Program {

        static void Main(string[] args) {

            //Load IoC container
            var container = new WindsorContainer();

            // Grab all IoC installers in Bin dir
            container.Install(
                FromAssembly.InDirectory(new AssemblyFilter(Environment.CurrentDirectory))
                );

            // Resolve all filters and order according to the order property
            var filters = container.ResolveAll<IFilter>().OrderBy(f => f.Order);

            // Resolve the registered pipeline implementation
            var pipeline = container.Resolve<IPipeline>();

            //Load and execute pipeline
            Console.WriteLine("Pipeline starting");

            foreach(var filter in filters) {
                pipeline.Register(filter);
            }

            pipeline.Execute(args[0]);

            Console.WriteLine("Pipeline completed");

        }
    }
}
