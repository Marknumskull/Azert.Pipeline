using System;
using System.Linq;
using Azert.Pipeline.Contracts;

namespace Azert.Pipeline.Example.ExplicitRegistration.Filters {
    public class Dots : IFilter {
        public int Order => 4;

        public object Process(object input) {
            Console.WriteLine(string.Join("", input.ToString().Select(s => s + ".").ToArray()));

            return input;
        }
    }
}