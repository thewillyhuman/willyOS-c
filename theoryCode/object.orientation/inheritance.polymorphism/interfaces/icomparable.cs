
namespace TPP.ObjectOrientation.InheritancePolymorphism {

    /// <summary>
    /// Interface to be implemented to compute the maximum value of to objects
    /// </summary>
    public interface IComparable {
        /// <summary>
        /// Compare method
        /// </summary>
        /// <param name="c">The object to be compared</param>
        /// <returns>A negative number if this is lower than c;
        /// zero if they are the same; 
        /// a positive number if this is greater than c.</returns>
        int Compare(IComparable c);
    }
}
