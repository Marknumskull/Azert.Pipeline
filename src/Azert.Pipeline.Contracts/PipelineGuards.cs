using System;
using System.Diagnostics.Contracts;

namespace Azert.Pipeline.Contracts {

    [ContractClassFor(typeof(IPipeline))]
    public class PipelineGuards : IPipeline {

        public void Register(IFilter filter) {
            Contract.Requires<ArgumentNullException>(filter != null, "Ensure the filter is not null when trying to register");
        }

        public object Execute<T>(T input) {
            Contract.Requires<ArgumentNullException>(input != null, "input cannot be null");
            return null;
        }

        public void Dispose() {

        }
    }
}