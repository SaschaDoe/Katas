using System;

namespace BMIFunctional
{
    public static partial class F
    {
        public static Validation<T> Validation<T>(ValidationError validationError) => new Validation<T>(validationError);
    }
    
    public class Validation<T>
    {
         internal ValidationError ValidationError { get; }
         internal T Value { get; }

         public bool Success => ValidationError == null;
         public bool NotValid => ValidationError != null;

         internal Validation(ValidationError validationError)
         {
             ValidationError = validationError ?? throw new ArgumentNullException(nameof(validationError));
             Value = default;
         }

         internal Validation(T right)
         {
             Value = right;
             ValidationError = null;
         }
         
         public static implicit operator Validation<T>(ValidationError left) => new Validation<T>(left);
         public static implicit operator Validation<T>(T right) => new Validation<T>(right);
         
         public TR Match<TR>(Func<ValidationError, TR> Validation, Func<T, TR> Success)
             => NotValid ? Validation(ValidationError) : Success(Value);
         
         public override string ToString() 
             => Match(
                 ex => $"Validation error: ({ex.Message})",
                 t => $"Success({t})");

    }
}