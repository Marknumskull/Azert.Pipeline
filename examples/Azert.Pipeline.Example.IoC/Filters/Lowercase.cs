using System;
using Azert.Pipeline.Contracts;

namespace Azert.Pipeline.Example.IoC.Filters {
    public class Lowercase : IFilter {
        public int Order => 1;

        public object Process(object input) {

            Console.WriteLine(input.ToString().ToLowerInvariant());

            return input;
        }
    }
}