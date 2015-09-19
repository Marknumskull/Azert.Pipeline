namespace Azert.Pipeline.Contracts {

    /// <summary>
    /// Interface to implement when a filter needs added to the pipeline
    /// This could call other methods in other classes or simply execute 
    /// statements in the Process method.
    /// 
    /// Ensure the returned object matches an expected input type for the
    /// filter that follows.
    /// </summary>
    public interface IFilter {

        /// <summary>
        /// Optional property to add the order in the pipeline this should be included.
        /// 
        /// This would be used if using DI to register the filters and you want to ensure
        /// the order is maintained. Extra flexibily but makes it less explict when glancing
        /// at filters what order they are in.
        /// </summary>
        int Order { get; }

        /// <summary>
        /// This should contain the statements or calls to execute this part of the pipeline
        /// The return object should match an expected type for the input for the following
        /// filter otherwise you will have a bad time.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        object Process(object input);
    }
}
