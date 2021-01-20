using System.Runtime.InteropServices;

namespace BMIFunctional
{
    public static partial class F
    {
        public static ValidationError ValidationError(string message) => new ValidationError(message);
    }
    
    public class ValidationError
    {
        public virtual string Message { get; }

        /// <inheritdoc />
        public override string ToString() => Message;
        
        protected ValidationError(){}

        internal ValidationError(string message)
        {
            this.Message = message;
        }

        public static implicit operator ValidationError(string message) => new ValidationError(message);
    }
}