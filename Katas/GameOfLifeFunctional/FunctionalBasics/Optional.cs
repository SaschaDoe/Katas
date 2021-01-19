using System;
using System.Collections.Generic;

namespace GameOfLifeFunctional.FunctionalBasics
{
    using static F;

   public static partial class F
   {
      /// <summary>
      /// Wraps a value into a some
      /// </summary>
      /// <param name="value"></param>
      /// <typeparam name="T"></typeparam>
      /// <returns></returns>
      public static Optional<T> Some<T>(T value) => new Option.Some<T>(value); 
      
      /// <summary>
      /// None value to show absence of data
      /// </summary>
      public static Option.None None => Option.None.Default;  
   }

   public struct Optional<T> : IEquatable<Option.None>, IEquatable<Optional<T>>
   {
      private readonly T _value;
      private readonly bool _isSome;
      private bool _isNone => !_isSome;

      private Optional(T value)
      {
         if (value == null)
            throw new ArgumentNullException();
         this._isSome = true;
         this._value = value;
      }

      public static implicit operator Optional<T>(Option.None _) => new Optional<T>();
      public static implicit operator Optional<T>(Option.Some<T> some) => new Optional<T>(some.Value);

      public static implicit operator Optional<T>(T value)
         => value == null ? None : Some(value);

      public R Match<R>(Func<R> none, Func<T, R> some)
          => _isSome ? some(_value) : none();

      public IEnumerable<T> AsEnumerable()
      {
         if (_isSome) yield return _value;
      }

      public bool Equals(Optional<T> other) 
         => this._isSome == other._isSome 
         && (this._isNone || this._value.Equals(other._value));

      public bool Equals(Option.None _) => _isNone;

      public static bool operator ==(Optional<T> @this, Optional<T> other) => @this.Equals(other);
      public static bool operator !=(Optional<T> @this, Optional<T> other) => !(@this == other);

      public override string ToString() => _isSome ? $"Some({_value})" : "None";
   }
   
   namespace Option
   {
      public struct None
      {
         internal static readonly None Default = new None();
      }

      public struct Some<T>
      {
         internal T Value { get; }

         internal Some(T value)
         {
            if (value == null)
               throw new ArgumentNullException(nameof(value)
                  , "Cannot wrap a null value in a 'Some'; use 'None' instead");
            Value = value;
         }
      }
   }
}