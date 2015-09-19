using System;
using System.Diagnostics.Contracts;

namespace Azert.Pipeline.Contracts {

    /// <summary>
    /// Contract for implementing a synchronous pipeline
    /// </summary>
    [ContractClass(typeof(PipelineGuards))]
    public interface IPipeline : IDisposable {

        /// <summary>
        /// Method to register filters with the pipeline
        /// </summary>
        /// <param name="filter">Implementation of IFilter</param>
        void Register(IFilter filter);

        /// <summary>
        /// Kicks off the pipeline. It will loop through every 
        /// registered filter and execute its process method
        /// </summary>
        /// <typeparam name="T">Type to send into the pipeline</typeparam>
        /// <param name="input">Object to feed into the pipeline</param>
        object Execute<T>(T input);
    }
}
