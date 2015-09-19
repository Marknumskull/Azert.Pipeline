using System;
using System.Linq;
using Azert.Pipeline.Contracts;

namespace Azert.Pipeline.Example.IoC.Filters {
    public class Reverse : IFilter {
        public int Order => 3;

        public object Process(object input) {
            Console.WriteLine(string.Join("", input.ToString().ToCharArray().Reverse().ToArray()));

            return input;
        }
    }
}