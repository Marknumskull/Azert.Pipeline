using System;
using Azert.Pipeline.Contracts;

namespace Azert.Pipeline.Example.IoC.Filters {
    public class Uppercase : IFilter {
        public int Order => 2;

        public object Process(object input) {
            Console.WriteLine(input.ToString().ToUpperInvariant());

            return input;
        }
    }
}