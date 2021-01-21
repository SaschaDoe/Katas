using System;

namespace RomanParsing
{
    public class Either<TL, TR>
    {
        private readonly TL _left;
        private readonly TR _right;
        private readonly bool _isLeft;

        public Either(TL left)
        {
            _left = left;
            _isLeft = true;
        }

        public Either(TR right)
        {
            _right = right;
            _isLeft = false;
        }
        public void Match(Action<TL> Left, Action<TR> Right)
            => Match(Left.ToFunc(), Right.ToFunc());
        
        public T Match<T>(Func<TL, T> leftFunc, Func<TR, T> rightFunc)
            => _isLeft ? leftFunc(_left) : rightFunc(_right);
        
        public static implicit operator Either<TL, TR>(TL left) => new Either<TL, TR>(left);

        public static implicit operator Either<TL, TR>(TR right) => new Either<TL, TR>(right);
    }
}