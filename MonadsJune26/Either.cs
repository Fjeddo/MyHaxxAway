using System.Diagnostics;

namespace MonadsJune26;

public readonly struct Either<TLeft, TRight>
{
    private readonly TLeft _left = default!;
    private readonly TRight _right = default!;
    
    public Either(TLeft left) => _left = left;

    public Either(TRight right) => _right = right;

    public T Match<T>(Func<TLeft, T> onLeft, Func<TRight, T> onRight)
    {
        if(_left != null)
        {
            return onLeft(_left);
        }

        return _right != null 
            ? onRight(_right) 
            : throw new UnreachableException("Left or Right must be a valid Either");
    }
}