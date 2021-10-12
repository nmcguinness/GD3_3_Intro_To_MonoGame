namespace GDLibrary.Interfaces
{
    /// <summary>
    /// Any class implementing this interface will provide DeepClone
    /// </summary>
    /// <example>
    /// public class Player : IDeepCloneable
    /// {
    /// }
    ///
    /// //store a reference to Player in this interface type
    /// IDeepCloneable p1 = new Player("max", "soldier_red.jpg")
    ///
    /// //store players in a List
    /// List<IDeepCloneable> myList = new List<IDeepCloneable>()
    /// </example>
    public interface IDeepCloneable
    {
        public object DeepClone();
    }
}