using System;
using System.Collections.Generic;
using System.Linq;

namespace Azert.Pipleline.Sync {
    using Azert.Pipeline.Contracts;

    /// <summary>
    /// Synchronous pipeline used to control process flow through an application
    /// </summary>
    public class Pipeline : IPipeline {

        private Queue<IFilter> _filters = new Queue<IFilter>();

        /// <summary>
        /// Called at application start ideally. 
        /// Used to register each filter. Filters are processed
        /// in the order in which they are registered
        /// </summary>
        /// <param name="filter"></param>
        /// <exception cref="ArgumentNullException">Raised if a null filter has been passed in</exception>
        public void Register(IFilter filter) {

            if(_filters == null) {
                _filters = new Queue<IFilter>();
            }

            _filters.Enqueue(filter);
        }

        /// <summary>
        /// Runs the pipeline from start to finish
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">An object to seed the pipeline with</param>
        /// <returns>Whatever object the final filter in the pipeline returns</returns>
        /// <exception cref="ArgumentNullException">Raised if a null input has been passed in</exception>
        /// <exception cref="InvalidOperationException">Raised if no filters have been registered</exception>
        public object Execute<T>(T input) {

            //Ensure filters are present before trying to process
            if(!_filters.Any())
                throw new InvalidOperationException("No filters have been registered, register your filters and try again.");

            //This could be transformed into a linq statement but for maintainability
            //I am keeping as shown below
            object previous = null;

            foreach(var filter in _filters) {
                previous = filter.Process(previous ?? input);
            }

            return previous;
        }
    }
}