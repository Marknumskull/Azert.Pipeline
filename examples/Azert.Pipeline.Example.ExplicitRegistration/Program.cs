using System;
using Azert.Pipeline.Example.ExplicitRegistration.Filters;

namespace Azert.Pipeline.Example.ExplicitRegistration {
    class Program {
        static void Main(string[] args) {

            //Load and execute pipeline
            Console.WriteLine("Pipeline starting");

            var pipeline = new Pipleline.Sync.Pipeline();

            // Explicitly register each filter
            // this determines order of execution
            pipeline.Register(new Lowercase());
            pipeline.Register(new Uppercase());
            pipeline.Register(new Reverse());
            pipeline.Register(new Dots());

            pipeline.Execute(args[0]);

            Console.WriteLine("Pipeline completed");
        }
    }
}
