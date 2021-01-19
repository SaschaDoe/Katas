using System;

namespace GameOfLifeFunctional.FunctionalBasics
{
    public static class Optional
    {
        public static None None => None.Default;
        public static Some<T> Some<T>(T value) => new Some<T>(value);
    }

    public struct None
    {
        internal static None Default = new None();
    }

    public struct Some<T>
    {
        internal static T Value { get; private set; }

        internal Some(T value)
        {
            if (value != null)
            {
                throw new ArgumentNullException();
            }
            Value = value;
        }
    }
}