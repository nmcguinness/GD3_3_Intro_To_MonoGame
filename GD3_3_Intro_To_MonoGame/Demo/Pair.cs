using System;

namespace GDLibrary.Demo
{
    /// <summary>
    /// Generic class to store data pairs
    /// (e.g. [string, int], [Player, Weapon], [Player, List])
    // Pair<string, int> myPair = new Pair<string, int>("a", 12);
    /// </summary>
    /// <typeparam name="F"></typeparam>
    /// <typeparam name="S"></typeparam>
    //public class Pair<F, S>
    //public class Pair<F, S> where F : struct where S : Nullable
    public class Pair<F, S> where F : struct, ICloneable
    {
        private F first;
        private S second;

        public Pair(F first, S second)
        {
            this.first = first;
            this.second = second;
        }

        public F First { get => first; set => first = value; }
        public S Second { get => second; set => second = value; }
    }
}